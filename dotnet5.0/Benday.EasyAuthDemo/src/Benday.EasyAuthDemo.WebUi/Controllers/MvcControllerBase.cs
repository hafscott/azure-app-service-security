using System;
using Microsoft.AspNetCore.Mvc;

namespace Benday.EasyAuthDemo.WebUi.Controllers
{
    public abstract class MvcControllerBase<TEditorViewModel> : Controller
    {
        protected virtual void BeforeReturnFromEdit(int? id, TEditorViewModel viewModel)
        {
            
        }
    }
}
