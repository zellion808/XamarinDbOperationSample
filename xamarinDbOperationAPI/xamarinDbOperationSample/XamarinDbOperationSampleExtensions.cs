﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace xamarinDbOperationAPI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for XamarinDbOperationSample.
    /// </summary>
    public static partial class XamarinDbOperationSampleExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IList<string> GetAll(this IXamarinDbOperationSample operations)
            {
                return Task.Factory.StartNew(s => ((IXamarinDbOperationSample)s).GetAllAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<string>> GetAllAsync(this IXamarinDbOperationSample operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAllWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void Create(this IXamarinDbOperationSample operations, string value)
            {
                Task.Factory.StartNew(s => ((IXamarinDbOperationSample)s).CreateAsync(value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task CreateAsync(this IXamarinDbOperationSample operations, string value, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.CreateWithHttpMessagesAsync(value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void GetById(this IXamarinDbOperationSample operations, int id)
            {
                Task.Factory.StartNew(s => ((IXamarinDbOperationSample)s).GetByIdAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task GetByIdAsync(this IXamarinDbOperationSample operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.GetByIdWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void Update(this IXamarinDbOperationSample operations, int id, string value)
            {
                Task.Factory.StartNew(s => ((IXamarinDbOperationSample)s).UpdateAsync(id, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task UpdateAsync(this IXamarinDbOperationSample operations, int id, string value, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.UpdateWithHttpMessagesAsync(id, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            public static void Delete(this IXamarinDbOperationSample operations, int id)
            {
                Task.Factory.StartNew(s => ((IXamarinDbOperationSample)s).DeleteAsync(id), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='id'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IXamarinDbOperationSample operations, int id, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(id, null, cancellationToken).ConfigureAwait(false);
            }

    }
}
