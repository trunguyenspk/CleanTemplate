using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Extensions
{
    public static class Utilities
    {
        public static bool IsNullOrEmpty(this IList array)
        {
            return (array == null || array.Count == 0);
        }
    }
}
