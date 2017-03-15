using CarManiacs.Business.Data.Contracts;

using System.Web.Mvc;

namespace CarManiacs.WebClient.ActionFilters
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        private IUnitOfWork unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                this.unitOfWork.SaveChanges();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}