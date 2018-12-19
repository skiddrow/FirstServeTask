//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//namespace testproj
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var method = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
//            var variable = Expression.Parameter(typeof(string), "a");
//            var assign = Expression.Assign(variable, Expression.Constant(42.ToString()));
//            var e = Expression.Call(null, method, variable);
//            var b = Expression.Block(new[] { variable }, assign, e);
//            Console.WriteLine(b);
//            foreach (var a in b.Expressions)
//                Console.WriteLine(a);
//            var lambda = Expression.Lambda<Action>(b);
//            lambda.Compile().DynamicInvoke();
//        }
//    }
//}