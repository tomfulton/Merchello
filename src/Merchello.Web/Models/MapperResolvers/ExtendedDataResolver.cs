﻿using System.Collections.Generic;
using AutoMapper;
using Merchello.Core.Models;

namespace Merchello.Web.Models.MapperResolvers
{
    /// <summary>
    /// Custom AutoMapper Resolver - Maps <see cref="ExtendedDataCollection"/> to an Enumerable
    /// </summary>
    /// <remarks>
    /// 
    /// Fixes issue M-211 http://issues.merchello.com/youtrack/issue/M-211
    /// 
    /// </remarks>
    public class ExtendedDataResolver : ValueResolver<IHasExtendedData, IEnumerable<KeyValuePair<string, string>>>
    {
        protected override IEnumerable<KeyValuePair<string, string>> ResolveCore(IHasExtendedData source)
        {
            return source.ExtendedData.AsEnumerable();
        }
    }
}