﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    class GroupComposite : GroupComponent
    {
        private List<GroupComponent> shapes = new List<GroupComponent>();
        public List<OrnamentBase> Ornaments = new List<OrnamentBase>();

        public override void Add(GroupComponent e)
        {
            shapes.Add(e);
        }
        public override void Remove(GroupComponent e)
        {
            shapes.Remove(e);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String(' ', depth) + name);

            // Recursively display child nodes
            foreach (GroupComponent component in shapes)
            {
                component.Display(depth + 2);
            }
        }
        public override void WriteToFile(System.IO.StreamWriter writer, int depth)
        {
            //Write every ornament to the file BEFORE the group is written.
            foreach(OrnamentBase orn in Ornaments)
            {
                writer.WriteLine(new String(' ', depth) + "ornament " + orn.getSide() + " \"" + orn.getText() + "\"");
            }

            writer.WriteLine(new String(' ', depth) + name);
            foreach (GroupComponent component in shapes)
            {
                component.WriteToFile(writer, depth + 2);
            }
        }
        public override List<GroupComponent> UnGroup()
        {
            //Just return the member since the grouplist in handled in the PlayingWithApplication.cs
            return shapes;
        }
        public override bool ContainsMember(GroupComponent shape)
        {
            return shapes.Contains(shape);
        }
        public override void ToggleSelected()
        {
            foreach (GroupComponent component in shapes)
            {
                component.ToggleSelected();
            }
        }
        public override bool isSelected()
        {
            bool selected = false;
            foreach (GroupComponent currentShape in shapes)
            {
                if (currentShape.isSelected())
                {
                    selected = true;
                }
            }
            return selected;
        }
        public override int Size(){
            return shapes.Count();
        }
        public override int GetMaxX()
        {
            int maxX = 0;
            foreach (GroupComponent component in shapes)
            {
                if (component.GetMaxX() > maxX)
                {
                    maxX = component.GetMaxX();
                }
            }
            return maxX;
        }
        public override int GetMaxY()
        {
            int maxY = 0;
            foreach (GroupComponent component in shapes)
            {
                if (component.GetMaxY() > maxY)
                {
                    maxY = component.GetMaxY();
                }
            }
            return maxY;
        }
        public override int GetMinX()
        {
            int minX = 10000;
            foreach (GroupComponent component in shapes)
            {
                if (component.GetMinX() < minX)
                {
                    minX = component.GetMinX();
                }
            }
            return minX;
        }
        public override int GetMinY()
        {
            int minY = 10000;
            foreach (GroupComponent component in shapes)
            {
                if (component.GetMinY() < minY)
                {
                    minY = component.GetMinY();
                }
            }
            return minY;
        }

        public override void setSelected(bool selected)
        {
            throw new NotImplementedException();
        }

        public override Color getBackColor()
        {
            throw new NotImplementedException();
        }

        public override void setBackColor(Color g)
        {
            throw new NotImplementedException();
        }

        public override int GetPosX()
        {
            throw new NotImplementedException();
        }

        public override int GetPosY()
        {
            throw new NotImplementedException();
        }

        public override int GetSizX()
        {
            throw new NotImplementedException();
        }

        public override int GetSizY()
        {
            throw new NotImplementedException();
        }

        public override void SetPosX(int posX)
        {
            throw new NotImplementedException();
        }

        public override void SetPosY(int posY)
        {
            throw new NotImplementedException();
        }

        public override void SetSizX(int sizX)
        {
            throw new NotImplementedException();
        }

        public override void SetSizY(int sizY)
        {
            throw new NotImplementedException();
        }

        public override void setName(string name)
        {
            this.name = name;
        }

        public override void AddOrnament(OrnamentBase ornament)
        {
            Ornaments.Add(ornament);
        }

        public override void DrawOrnaments(Graphics g)
        {
            foreach (OrnamentBase orn in Ornaments)
            {
                orn.drawOrnament(GetMinX(), GetMinY(), GetMaxX() - GetMinX(), GetMaxY() - GetMinY(), g);
            }
        }
    }
}
