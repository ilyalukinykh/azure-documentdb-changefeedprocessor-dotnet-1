//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  Licensed under the MIT license.
//----------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Azure.Documents.ChangeFeedProcessor.Exceptions;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace Microsoft.Azure.Documents.ChangeFeedProcessor
{
    public interface IChangeFeedObserverContext
    {
        /// <summary>
        /// Gets the id of the partition for current event.
        /// </summary>
        string PartitionKeyRangeId { get; }

        /// <summary>
        /// The response from the underlying <see cref="Microsoft.Azure.Documents.Linq.IDocumentQuery&lt;T&gt;.ExecuteNextAsync"/> call.
        /// </summary>
        IFeedResponse<Document> FeedResponse { get; }

        /// <summary>
        /// Checkpoints progress of a stream. This method is valid only if manual checkpoint was configured. 
        /// Client may accept multiple change feed batches to process in parallel.
        /// Once first N document processing was finished the client can call checkpoint on the last completed batches in the row.
        /// In case of automatic checkpointing this is method throws.
        /// </summary>
        /// <exception cref="LeaseLostException">Thrown if other host acquired the lease or the lease was deleted</exception>
        Task CheckpointAsync();
    }
}