using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Csharp7_features.Features;

namespace Csharp7_features
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            //OutExample();
            //TupleExample();
            //PatternMatchingExamples();
            //RefExample();
            //LocalsExample();
            //ExpressionMembers();
            //ValueTaskExample();
            NameOfExample();
        }

        private static void NameOfExample()
        {
            var csharp6Features = new Csharp6Features();
            try
            {
                csharp6Features.NameOfExample("prueba");
                csharp6Features.NameOfExample(null);
            }
            catch (Exception e)
            {
                e.LogException(); //Esto salió de una extensión de las excepciones
            }
        }

        private static void ValueTaskExample()
        {
            var vtf = new ValueTaskFeature();
            var vtfResult = vtf.Func();
            Console.WriteLine(vtfResult.Result);

            /// Ver librería para auditar tiempo
            var res = vtf.CachedFunc();
            var res2 = vtf.CachedFunc();
            Console.WriteLine(res == res2);
            Console.WriteLine(res.Result == res2.Result);
        }

        private static void ExpressionMembers()
        {
            var exp = new ExpressionMemberExample("PRUEBA");
            var generation = GC.GetGeneration(exp);
            GC.Collect(generation, GCCollectionMode.Forced, false, true);
            exp = null;
            GC.Collect();

        }
        private static void RefExample()
        {
            //HOW TO DECLARE A MATRIX
        }

        private static void LocalsExample()
        {
            try
            {
                var iterador = AlphabetIterator.AlphabetSubset('f', 'b');
                foreach (var item in iterador)
                {

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var iterador = AlphabetIterator.AlphabetSubset2('f', 'b');
                foreach (var item in iterador)
                {

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var iterador = AlphabetIterator.AlphabetSubsetUsingLocals('f', 'b');
                foreach (var item in iterador)
                {

                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                var p = AlphabetIteratorWithTask
                .PerformLongRunningWork("1", 1, "1")
                .ContinueWith((task) =>
                {
                    Console.WriteLine(task.Result);
                });
                //proba.RunSynchronously();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PatternMatchingExamples()
        {
            Console.WriteLine("__________Pattern Matching feature________________");
            var sumFlatten = PatternMatchingFeature.SumFlatten(PatternMatchingFeature.Numbers);
            Console.WriteLine(sumFlatten);
            sumFlatten = PatternMatchingFeature.SumFlatten2(PatternMatchingFeature.Numbers);
            Console.WriteLine(sumFlatten);
            Console.WriteLine("__________Pattern Matching feature________________");
        }

        private static void TupleExample()
        {
            Console.WriteLine("__________Tuple feature________________");

            //Tuple Instanciation
            TupleFeature.CreateTuple();


            var maxAndMin = TupleFeature.GetMaxAndMin(new List<int> { 2, 3, 5, 10, 22, -1 });
            Console.WriteLine("(" + maxAndMin.Max.ToString() + ") - (" + maxAndMin.Min.ToString() + ")");

            //Deconstruction
            var p = new TupleFeature.Point(1.1, 2.2);
            (double X, double Y) = p;
            var (XX, YY) = p;

            Console.WriteLine("_____________________________________");
        }

        private static void OutExample()
        {
            Console.WriteLine("__________OUT feature________________");
            OutFeature.OldExample();
            OutFeature.NewExample();
            Console.WriteLine("_____________________________________");
        }
    }
}
