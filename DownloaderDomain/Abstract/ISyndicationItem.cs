using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DownloaderDomain.Abstract
{
    public interface ISyndicationItem
    {
        string Id {get;}
        string Title { get; }
        string Summary { get; }
        DateTime PublishDate { get; }
    }
}
