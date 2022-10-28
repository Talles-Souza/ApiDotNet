using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hypermedia.Filters
{
    public class HyperMediaFilter : ResultFilterAttribute
    {
        private readonly HyperMediaFileOptions hyperMediaFileOptions;

        public HyperMediaFilter(HyperMediaFileOptions hyperMediaFileOptions)
        {
            this.hyperMediaFileOptions = hyperMediaFileOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichReseult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichReseult(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult objectResult)
            {
                var enricher = hyperMediaFileOptions.ContentResponseEnricherList
                    .FirstOrDefault(x => x.CanEnrich(context));
                if (enricher != null) Task.FromResult(enricher.Enrich(context)); 
            }

        }
    }
}
    