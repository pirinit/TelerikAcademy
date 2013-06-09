using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace FreeContentCatalog
{
    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.Url, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int maxElementsToList)
        {
            IEnumerable<IContent> contentToList = 
                from c 
                in this.title[title] 
                select c;

            return contentToList.Take(maxElementsToList);
        }


        public int UpdateContent(string oldUrl, string newUrl)
        {

            List<IContent> contentToList = this.url[oldUrl].ToList();

            this.url.Remove(oldUrl);
            foreach (IContent content in contentToList)
            {
                content.Url = newUrl;
                this.url.Add(content.Url, content);
            }

            return contentToList.Count;
        }
    }
}
