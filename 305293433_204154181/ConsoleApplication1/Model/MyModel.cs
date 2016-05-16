using ATP2016Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Controller;

namespace ATP2016Project.Model
{
    public class MyModel : IModel
    {
        private IController controller;

        public MyModel(IController controller)
        {
            this.controller = controller;
        }
    }
}
