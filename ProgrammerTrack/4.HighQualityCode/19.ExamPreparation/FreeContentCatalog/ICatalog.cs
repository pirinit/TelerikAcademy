using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    public interface ICatalog
    {
        /// <summary>
        /// Adds content to the catalog.
        /// </summary>
        /// <param name="content"></param>
        void Add(IContent content);

        /// <summary>
        /// Retrieves IEnumerable of content matching the given title.
        /// </summary>
        /// <param name="title">title to search for</param>
        /// <param name="maxElementsToList">Max number of contents to be returned</param>
        IEnumerable<IContent> GetListContent(string title, int maxElementsToList);

        /// <summary>
        /// Changes the url of all content in the catalog with oldUrl to newUrl
        /// </summary>
        /// <returns>count of changes</returns>
        int UpdateContent(string oldUrl, string newUrl);
    }
}
