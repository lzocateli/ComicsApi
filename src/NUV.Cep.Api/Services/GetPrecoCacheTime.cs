using Microsoft.Extensions.Configuration;
using System;

namespace CBL.Custom.Services
{
    public static class GetPrecoCacheTime
    {
        public static DateTime ExpireAt(IConfiguration confiruration)
        {
            var hour = confiruration.GetSection("AppConfig:CacheExpire:Preco:daily")?.Value;

            if (!DateTime.TryParse($"{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}T{hour}", out DateTime expireTime))
            {
                expireTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 05, 0, 0);
            }

            var expireDiff = expireTime - DateTime.Now;
            if (expireDiff.Minutes <= 0)
            {
                expireTime = expireTime.AddDays(1);
            }

            return expireTime;
        }
    }
}