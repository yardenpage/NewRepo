using ATP2016Project.Model;
using ATP2016Project.View;

namespace ATP2016Project.Controller
{
    public class AModel
    {
        private IModel imodel;
        private IView iview;

        public AModel(IModel imodel, IView iview)
        {
            this.imodel = imodel;
            this.iview = iview;
        }
    }
}