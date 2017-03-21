using CarManiacs.Business.Data.Contracts;

using Bytes2you.Validation;
using System.Web.Mvc;

namespace CarManiacs.WebClient.ActionFilters
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        protected IUnitOfWork unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            IUnitOfWork uow = DependencyResolver.Current.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            Guard.WhenArgument(uow, "unitOfWork").IsNull().Throw();
            this.unitOfWork = uow;

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Guard.WhenArgument(this.unitOfWork, "unitOfWork").IsNull().Throw();
            if (filterContext.Exception == null)
            {
                this.unitOfWork.SaveChanges();
            }

            base.OnActionExecuted(filterContext);
        }
    }
}