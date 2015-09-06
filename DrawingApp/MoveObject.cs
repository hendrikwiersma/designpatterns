﻿namespace DrawingApp
{
    class MoveObject : Visitable
    {
        private BasisFiguur shape;
        private int new_x_pos;
        private int new_y_pos;

        public MoveObject(BasisFiguur shape, int new_x_pos, int new_y_pos)
        {
            this.shape = shape;
            this.new_x_pos = new_x_pos;
            this.new_y_pos = new_y_pos;
        }

        public void accept(Visitor visitor)
        {
            visitor.visit(this);
        }
        public BasisFiguur getShape()
        {
            return shape;
        }
        public int getX()
        {
            return new_x_pos;
        }
        public int getY()
        {
            return new_y_pos;
        }
    }
}
