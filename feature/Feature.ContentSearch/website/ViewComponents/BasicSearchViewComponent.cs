using Feature.ContentSearch.Models;
using Feature.ContentSearch.Services;
using Microsoft.AspNetCore.Mvc;
using Sitecore.AspNet.RenderingEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Feature.ContentSearch.ViewComponents
{
    public class BasicSearchViewComponent : ViewComponent
    {
        private readonly IGraphQLService _graphQLService;

        public BasicSearchViewComponent(IGraphQLService graphQLService)
        {
            _graphQLService = graphQLService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var language = "en";
            var sitecoreRenderingContext = HttpContext.GetSitecoreRenderingContext();
            var rootItemId = "/sitecore/content/myproject/home";
            var isEditingMode = sitecoreRenderingContext.Response?.Content?.Sitecore?.Context?.IsEditing ?? false;

            var request = new SearchRequest
            {
                language = language,
                rootItem = rootItemId,
                fieldsEqual = new List<SearchRequest.FieldsEqualValue>()
                {
                    new SearchRequest.FieldsEqualValue("_templateName", "App Route")
                },
                facetOn = new List<string> { "_language" },
                keyword = Request.Query["keyword"],
                after = "0",
                first = 10
            };

            var response = await _graphQLService.Search(request, isEditingMode);

            response.keyword = Request.Query["keyword"];

            return View(response);
        }
    }
}
