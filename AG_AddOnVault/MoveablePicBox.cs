using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AG_AddOnTool
{
    public class MovablePicBox : System.Windows.Forms.PictureBox
    {
        // Used to store the current cursor shape when we start
        // to move the control
        private Cursor m_CurrentCursor;
        // Holds the mouse position relative to the inside of
        // our control when the mouse button goes down
        private Point m_CursorOffset;
        // Used by the MoveMove event handler to show that the
        // setup to move the control has completed
        private bool m_Moving;

        public MovablePicBox() : base()
        {
            //base.InitLayout();
            this.Cursor = Cursors.Hand;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MovablePicBox
            // 
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovablePicBox_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovablePicBox_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovablePicBox_MouseUp);
            this.ResumeLayout(false);

        }

        private void MovablePicBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Check to see if the correct button has been pressed
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                // If so, save the current cursor and
                m_CurrentCursor = base.Cursor;

                // replace it with our new image that says were in Movable mode
                base.Cursor = Cursors.SizeAll;

                // Save the location of the mouse pointer relative to the top-left
                // corner of our control
                m_CursorOffset = e.Location;

                // Set the mode flag to signal the MouseMove event handler that it
                // needs to now calculate new positions for our control
                m_Moving = true;
            }
        }

        private void MovablePicBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // The button was released, so we're going back to Static mode.
            m_Moving = false;

            // Restore the cursor image to the way we found it when the mouse
            // button was pressed
            base.Cursor = m_CurrentCursor;
        }

        private void MovablePicBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // Check which mode we're in. If we're supposed to be moving
            // our control
            if (m_Moving)
            {
                // get the screen position of the mouse pointer and map it
                // to the position relative to the top-left corner of our
                // parent container
                Point clientPosition = base.Parent.PointToClient(System.Windows.Forms.Cursor.Position);

                // Calculate the new position of our control, maintaining
                // the relative position stored by the MoveDown event
                Point adjustedLocation = new Point(clientPosition.X - m_CursorOffset.X, clientPosition.Y - m_CursorOffset.Y);

                // Set the new position of our control
                MoveControlWithinBounds(adjustedLocation);
                //base.Location = adjustedLocation;
            }
        }

        private void MoveControlWithinBounds()
        {
            if (base.IsHandleCreated)
            {
                var _with1 = base.Location;
                MoveControlWithinBounds(new Point(_with1.X, _with1.Y));
            }
        }


        private void MoveControlWithinBounds(Point location)
        {
            if (base.IsHandleCreated)
            {
                int x = location.X;
                int y = location.Y;

                var _with1 = base.Parent.ClientRectangle;
                if (x > _with1.Right - base.Width)
                {
                    x = _with1.Right - base.Width;
                }

                if (y > _with1.Bottom - base.Height)
                {
                    y = _with1.Bottom - base.Height;
                }

                if (x < _with1.Left)
                {
                    x = _with1.Left;
                }

                if (y < _with1.Top)
                {
                    y = _with1.Top;
                }
                base.Location = new Point(x, y);
            }
        }

    }
}
