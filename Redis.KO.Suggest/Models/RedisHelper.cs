using CityDataSource;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Redis
{
    public class RedisHelper
    {
        public static IDatabase conn = null;
        public static Dictionary<string,string> RedisConnectionAndUpload(string connectionString)
        {
            var dict = new Dictionary<string, string>()
            ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(configuration: connectionString);
            
            conn = muxer.GetDatabase();
            muxer.Wait(conn.PingAsync());

            List<City> citys = CityDataSource.CityDataSource.GetCitys();

            if (conn.StringGet(key: "IsValue").IsNull)
            {
                var oneByone = new Stopwatch();
                oneByone.Start();
                int i = 0;

                citys.ToList().ForEach(c =>
                {
                    i++;
                    conn.HashSetAsync("Citys:Data:" + c.Id.ToString(), c.ToHashEntries());

                    List<string> prefix = GetPrefix(c.Name);

                    prefix.Concat(GetPrefix(c.Code));

                    if (!string.IsNullOrEmpty(c.Name)) 
                        conn.SortedSetAdd(key: "CityName", member: c.Name, score: 0);
                    if (!string.IsNullOrEmpty(c.Code))
                        conn.SortedSetAdd(key: "CityCode", member: c.Code, score: 0);

                    foreach (var p in prefix)
                    {
                        conn.SortedSetAdd("Citys:index:" + p, c.Id, 0);
                    }
                });
                oneByone.Stop();
                dict.Add(key: "OneByOne Elapsed Milliseconds: ", value: oneByone.ElapsedMilliseconds.ToString());
                dict.Add(key: "OneByOne Elapsed Seconds: ", value: (oneByone.ElapsedMilliseconds/1000).ToString());

                var whole = new Stopwatch();
                whole.Start();
                conn.StringSet(key: "cityslist", value: Serialize(citys));
                whole.Stop();
                dict.Add(key: "Whole Elapsed Milliseconds: ", value: whole.ElapsedMilliseconds.ToString());
                dict.Add(key: "whole Elapsed Seconds: ", value: (whole.ElapsedMilliseconds / 1000).ToString());

                conn.StringSet(key: "IsValue", value: true);
            }
            return dict;

        }

        public static List<City> GetCityByCode(string name)
        {
            RedisValue[] rvs = conn.SortedSetRangeByRank("Citys:index:" + name.ToLower());

            var citys = new List<City>();

            foreach (var r in rvs)
            {                
                HashEntry[] rvh = conn.HashGetAll("Citys:Data:" + r);
                citys.Add(RedisUtils.ConvertFromRedis<City>(rvh));
            }
            return citys;
        }

        public static List<string> GetPrefix(string word)
        {

            if (string.IsNullOrEmpty(word))
                return new List<string>();

            word = word.ToLower();
            var hs = new List<string>();

            //string[] wordsSplit = word.Split(separator: new char[] { ' ' });

            var wordsSplit = new string[] { word };

            foreach (var w in wordsSplit)
            {
                int i = 2;
                for (; i <= w.Length;)
                {
                    hs.Add(w.Substring(0, i++));
                }

            }

            return hs;
        }

        public static byte[] Serialize(List<City> city)
        {
            var bfr = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bfr.Serialize(ms, city);
                return ms.ToArray();
            }
        }
    }   
}
