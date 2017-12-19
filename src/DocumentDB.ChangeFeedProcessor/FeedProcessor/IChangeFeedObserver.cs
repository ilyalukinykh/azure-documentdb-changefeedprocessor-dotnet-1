﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  Licensed under the MIT license.
//----------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;

namespace Microsoft.Azure.Documents.ChangeFeedProcessor.FeedProcessor
{
    /// <summary>
    /// This interface is used to deliver change events to document feed observers.
    /// </summary>
    public interface IChangeFeedObserver
    {
        /// <summary>
        /// This is called when change feed observer is opened.
        /// </summary>
        /// <param name="context">The context specifying partition for this observer, etc.</param>
        /// <returns>A Task to allow asynchronous execution.</returns>
        Task OpenAsync(IChangeFeedObserverContext context);

        /// <summary>
        /// This is called when change feed observer is closed.
        /// </summary>
        /// <param name="context">The context specifying partition for this observer, etc.</param>
        /// <param name="reason">Specifies the reason the observer is closed.</param>
        /// <returns>A Task to allow asynchronous execution.</returns>
        Task CloseAsync(IChangeFeedObserverContext context, ChangeFeedObserverCloseReason reason);

        /// <summary>
        /// This is called when document changes are available on change feed.
        /// </summary>
        /// <param name="context">The context specifying partition for this change event, etc.</param>
        /// <param name="docs">The documents changed.</param>
        /// <returns>A Task to allow asynchronous execution.</returns>
        Task ProcessChangesAsync(IChangeFeedObserverContext context, IReadOnlyList<Document> docs);
    }
}