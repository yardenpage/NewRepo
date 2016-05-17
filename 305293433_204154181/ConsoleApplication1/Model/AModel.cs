using ATP2016Project.Model;
using ATP2016Project.View;

namespace ATP2016Project.Controller
{
    /// <summary>
    /// class  AModel
    /// </summary>
    public class AModel
    {
        private IModel imodel;
        private IView iview;
        /// <summary>
        /// constructor of AModel
        /// </summary>
        /// <param name="imodel"></param>
        /// <param name="iview"></param>
        public AModel(IModel imodel, IView iview)
        {
            this.imodel = imodel;
            this.iview = iview;
        }
    }
}