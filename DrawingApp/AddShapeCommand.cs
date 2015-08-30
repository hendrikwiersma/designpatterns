﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    class AddShapeCommand : UndoableCommand
    {
        private Shape shape;
        private Controller controller;

        // Constructor
        public AddShapeCommand(Controller controller, Shape shape)
        {
            this.shape = shape;
            this.controller = controller;
        }

        // Execute new command
        public override void Execute()
        {
            controller.AddShape(shape);
        }

        // Unexecute last command
        public override void UnExecute()
        {
            controller.RemoveShape(shape);

        }
    }
}