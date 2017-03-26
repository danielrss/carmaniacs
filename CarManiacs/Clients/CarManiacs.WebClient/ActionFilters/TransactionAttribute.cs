using Bytes2you.Validation;
using CarManiacs.Business.Data.Contracts;
using System.Web.Mvc;

namespace CarManiacs.WebClient.ActionFilters
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        protected IEfUnitOfWork unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            IEfUnitOfWork uow = DependencyResolver.Current.GetService(typeof(IEfUnitOfWork)) as IEfUnitOfWork;
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