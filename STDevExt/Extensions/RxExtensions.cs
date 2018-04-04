using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;

namespace STDevExt.Extensions
{
    public static class RxExtensions
    {
        public static IObservable<TElement> WhereNotNull<TElement>(this IObservable<TElement> observable) where TElement : class
        {
            return observable
                .Where(value => value != null);
        }

        public static IObservable<TElement> WhereNull<TElement>(this IObservable<TElement> observable) where TElement : class
        {
            return observable
                .Where(value => value is null);
        }

        public static IObservable<TSource> WhereNotEmpty<TSource>(this IObservable<TSource> observable) where TSource : ICollection
        {
            return observable
                .Where(list => list.Count > 0);
        }

        public static IObservable<string> WhereNotEmpty(this IObservable<string> observable)
        {
            return observable
                .Where(list => list.Count() > 0);
        }

        public static IObservable<TSource> WhereEmpty<TSource>(this IObservable<TSource> observable) where TSource : ICollection
        {
            return observable
                .Where(list => list.Count == 0);
        }

        public static IObservable<string> WhereEmpty(this IObservable<string> observable)
        {
            return observable
                .Where(list => list.Count() == 0);
        }

        public static IObservable<bool> WhereTrue(this IObservable<bool> observable)
        {
            return observable
                .Where(value => value);
        }

        public static IObservable<bool> WhereFalse(this IObservable<bool> observable)
        {
            return observable
                .Where(value => !value);
        }

        public static IObservable<TElement> RetryAndCatch<TElement>(this IObservable<TElement> observable, int count = 3) where TElement : class
        {
            return observable
                .Retry(count)
                .Catch(Observable.Return<TElement>(null));
        }

        public static IObservable<TElement> SelectTo<TSource, TElement>(this IObservable<TSource> source, TElement value)
        {
            return source
                .Select(_ => value);
        }
        
    }
}
