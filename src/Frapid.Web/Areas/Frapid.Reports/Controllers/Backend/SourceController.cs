﻿using System.Collections.Generic;
using System.Web.Mvc;
using Frapid.Reports.Engine;
using Frapid.Reports.Engine.Model;
using Frapid.Reports.Helpers;

namespace Frapid.Reports.Controllers.Backend
{
    public class SourceController : BackendReportController
    {
        [Route("dashboard/reports/header")]
        public ActionResult GetHeader(string path)
        {
            using (var generator = new Generator(this.Tenant, null, null))
            {
                generator.Report = new Report
                {
                    HasHeader = true,
                    DataSources = new List<DataSource>(),
                    Tenant = this.Tenant
                };

                string contents = generator.Generate(this.Tenant);
                return this.Content(contents, "text/html");
            }
        }

        [Route("dashboard/reports/source/{*path}")]
        public ActionResult Index(string path)
        {
            return this.View("~/Areas/Frapid.Reports/Views/Source.cshtml", path);
        }

        [ActionName("ReportMarkup")]
        [ChildActionOnly]
        public ActionResult Markup(string path)
        {
            var parameters = ParameterHelper.GetParameters(this.Request.QueryString);

            using (var generator = new Generator(this.Tenant, path, parameters))
            {
                string contents = generator.Generate(this.Tenant);
                return this.Content(contents, "text/html");
            }
        }
    }
}