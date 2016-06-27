using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Execution;

namespace Mspend.Framework.Extensions
{
    public static class AutoMapperExtensions
    {
        public static TDst Map<TSrc, TDst>(this TSrc src)
        {
            try
            {
                return Mapper.Map<TSrc, TDst>(src);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static TDst Map<TDst>(this object src)
        {
            if (src == null)
            {
                return default(TDst);
            }
            try
            {
                return Mapper.Map<TDst>(src);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public static object Map(this object src, object dst)
        {
            try
            {
                return Mapper.Map(src, dst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static TDst Map<TDst>(this object src, TDst dst)
        {
            try
            {
                return Mapper.Map(src, dst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static IEnumerable<TDst> Maps<TSrc, TDst>(this IEnumerable<TSrc> src)
        {
            try
            {
                var res = Mapper.Map<IEnumerable<TDst>>(src);
                return res;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public static IEnumerable<TDst> Maps<TSrc, TDst>(this IEnumerable<TSrc> src, IDictionary<Type, Type> maps)
        {
            var lst = src.ToList();
            try
            {
                return !lst.Any() ? Enumerable.Empty<TDst>() : Mapper.Map<IEnumerable<TSrc>, IEnumerable<TDst>>(lst);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
