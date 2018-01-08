using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace graphs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // image for the graph
        private Bitmap GraphImage;

        private void btnDraw_Click(object sender, EventArgs e)
        {
            // new bitmap with the size of the pictureBox
            GraphImage = new Bitmap(pboxGraph.ClientSize.Width, pboxGraph.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(GraphImage))
            { 
                // clear the area with white color
                gr.Clear(Color.White);

                // set smoothing mode so the graph will be smooth in between points
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                // use a pen with thickness set to 0 so that it draws the thinnest line possible, with no scaling
                using (Pen thin_pen = new Pen(Color.Purple, 0))
                {
                    // get the bounds, use trackbars instead of textboxes to avoid errors
                    double xmin = -tbarXmin.Value * Math.PI;
                    double xmax = tbarXmax.Value * Math.PI;
                    double ymin = -tbarYmin.Value;
                    double ymax = tbarYmax.Value;

                    // scale to make the area fit in the pictureBox
                    // parameters for Transform constructor
                    // get pictureBox's 3 corners mapped, 4th is automatically calculated
                    /* subtract ymin from ymax since the rectangle's height is negative, 
                     * and a regular coordinate system has the Y coordinate increasing upwards, not downwards */
                    RectangleF world_coords = new RectangleF(
                        (float)xmin, (float)ymax,
                        (float)(xmax - xmin),
                        (float)(ymin - ymax));
                    PointF[] device_coords =
                    {
                        new PointF(0, 0),
                        new PointF(pboxGraph.ClientSize.Width, 0),
                        new PointF(0, pboxGraph.ClientSize.Height),
                    };
                    // use transform for all of: skewing, scaling, rotating, translating
                    gr.Transform = new Matrix(world_coords, device_coords);

                    /* find the first multiple of Pi < xmin, draw a large tick mark for the value and other X values starting from that point,
                     * up to the maximum X value, skipping the value of Pi each time
                     * go back, adding small tick marks for the values midway between the previous values */
                    // draw the x-axis
                    double start_x = Math.PI * ((int)(xmin - 1));
                    gr.DrawLine(thin_pen, (float)xmin, 0, (float)xmax, 0);
                    float dy = (float)((ymax - ymin) / 30.0);
                    for (double x = start_x; x <= xmax; x += Math.PI)
                    {
                        gr.DrawLine(thin_pen, (float)x, -2 * dy, (float)x, 2 * dy);
                    }
                    for (double x = start_x + Math.PI / 2.0; x <= xmax; x += Math.PI)
                    {
                        gr.DrawLine(thin_pen, (float)x, -dy, (float)x, dy);
                    }


                    /* similarly here, draw large ticks for multiples of 1 along the Y axis,
                     * draw smaller ticks for the values in between (-0.5, 0.5, 1.5, ...) */
                    // draw the y-axis
                    double start_y = (int)ymin - 1;
                    gr.DrawLine(thin_pen, 0, (float)ymin, 0, (float)ymax);
                    float dx = (float)((xmax - xmin) / 60.0);
                    for (double y = start_y; y <= ymax; y += 1.0)
                    {
                        gr.DrawLine(thin_pen, -2 * dx, (float)y, 2 * dx, (float)y);
                    }
                    for (double y = start_y + 0.5; y <= ymax; y += 1.0)
                    {
                        gr.DrawLine(thin_pen, -dx, (float)y, dx, (float)y);
                    }

                    // draw vert. asymptotes using DashPattern (draw 5 then skip 5, repeat)
                    thin_pen.DashPattern = new float[] { 5, 5 };
                    for (double x = start_x + Math.PI / 2.0; x <= xmax; x += Math.PI)
                    {
                        gr.DrawLine(thin_pen, (float)x, (float)ymin, (float)x, (float)ymax);
                    }

                    // draw horiz. asymptotes (y=+/-1 to show maximum/minimum values of sine/cosine)
                    gr.DrawLine(thin_pen, (float)xmin, 1, (float)xmax, 1);
                    gr.DrawLine(thin_pen, (float)xmin, -1, (float)xmax, -1);
                    thin_pen.DashStyle = DashStyle.Solid;

                    /* this matrix does the opposite of what the original one does,
                     * it maps the points on the pictureBox back to points in world coordinate space,
                     * makes an array of 2 points 1 pixel apart in pictureBox coordinates,
                     * then uses the inverted transformation to map these points back to world coordinate space,
                     * the difference between in those points' X coordinates tells how far apart 'dx' in coordinate space points must be
                     * to be 1 pixel apart on the pictureBox in the X direction,
                     * all of this to tell the program what X values to plot, since it's drawing in world coordinates 
                     * and the Graphics object's transformation is converting the result so it fits the pictureBox */
                    // check how big a pixel is before scaling
                    Matrix inverse = gr.Transform;
                    inverse.Invert();
                    PointF[] pixel_pts =
                    {
                        new PointF(0, 0),
                        new PointF(1, 0),
                    };
                    inverse.TransformPoints(pixel_pts);
                    dx = pixel_pts[1].X - pixel_pts[0].X;

                    // add sine's points
                    // loop from xmin to xmax, each time increase x by dx, effectively drawing 1 point for each pixel in the X direction
                    List<PointF> sine_points = new List<PointF>();
                    for (float x = (float)xmin; x <= xmax; x += dx)
                    {
                        sine_points.Add(new PointF(x, (float)Math.Sin(x)));
                    }
                    thin_pen.Color = Color.DarkViolet;
                    gr.DrawLines(thin_pen, sine_points.ToArray());

                    // add cosine's points
                    // apply the same technique that's been used in sine drawing
                    List<PointF> cosine_points = new List<PointF>();
                    for (float x = (float)xmin; x <= xmax; x += dx)
                    {
                        cosine_points.Add(new PointF(x, (float)Math.Cos(x)));
                    }
                    thin_pen.Color = Color.Violet;
                    gr.DrawLines(thin_pen, cosine_points.ToArray());

                    // add tangent's points
                    List<PointF> tangent_points = new List<PointF>();
                    double old_value = Math.Tan(xmin);
                    thin_pen.Color = Color.Black;
                    for (float x = (float)xmin; x <= xmax; x += dx)
                    {
                        // check if there's a discontinuity by comparing the current and the next value of the loop
                        /* check has to be done since tg(x) is undefined for (Pi/2 + k*Pi),
                         * however, since Math.Pi returns these numbers for those X values 
                         * it's not obvious when the program shouldn't plot a value */
                        double new_value = Math.Tan(x);
                        if ((Math.Abs(new_value - old_value) > 10) &&
                            (Math.Sign(new_value) != Math.Sign(old_value)))
                        {
                            if (tangent_points.Count > 1)
                                gr.DrawLines(thin_pen, tangent_points.ToArray());
                            tangent_points = new List<PointF>();
                        }
                        else
                        {
                            tangent_points.Add(new PointF(x, (float)Math.Tan(x)));
                        }
                    }
                    if (tangent_points.Count > 1)
                        gr.DrawLines(thin_pen, tangent_points.ToArray());
                }
            }

            // draw the result
            pboxGraph.Image = GraphImage;
        }

        // saving the pictureBox to a file
        private void btnSave_Click(object sender, EventArgs e)
        {
            sfd.ShowDialog();

            string fileName = sfd.FileName;

            if(fileName == null || fileName == "")
            {
                MessageBox.Show("Please enter a name for the file!");
            }
            else
            {
                if(pboxGraph.Image == null)
                {
                    MessageBox.Show("There's nothing to save!");
                }
                else
                {
                    pboxGraph.Image.Save(fileName + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        // make fern method

        private float[] Prob = { 0.01f, 0.85f, 0.08f, 0.06f };
        private float[,,] Func =
        {
            {
                {0, 0},
                {0, 0.16f},
            },
            {
                {0.85f, 0.04f},
                {-0.04f, 0.85f},
            },
            {
                {0.2f, -0.26f},
                {0.23f, 0.22f},
            },
            {
                {-0.15f, 0.28f},
                {0.26f, 0.24f},
            },
        };
        private float[,] Plus =
        {
            {0, 0},
            {0, 1.6f},
            {0, 1.6f},
            {0, 0.44f},
        };

        private void MakeFern()
        {
            int wid = pboxGraph.ClientSize.Width;
            int hgt = pboxGraph.ClientSize.Height;
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.Clear(pboxGraph.BackColor);

                Random rnd = new Random();
                int func_num = 0, ix, iy;
                float x = 1, y = 1, x1, y1;
                for (int i = 1; i <= 100000; i++)
                {
                    double num = rnd.NextDouble();
                    for (int j = 0; j <= 3; j++)
                    {
                        num = num - Prob[j];
                        if (num <= 0)
                        {
                            func_num = j;
                            break;
                        }
                    }

                    x1 = x * Func[func_num, 0, 0] +
                         y * Func[func_num, 0, 1] +
                         Plus[func_num, 0];
                    y1 = x * Func[func_num, 1, 0] +
                         y * Func[func_num, 1, 1] +
                         Plus[func_num, 1];
                    x = x1;
                    y = y1;

                    const float w_xmin = -4;
                    const float w_xmax = 4;
                    const float w_ymin = -0.1f;
                    const float w_ymax = 10.1f;
                    const float w_wid = w_xmax - w_xmin;
                    const float w_hgt = w_ymax - w_ymin;
                    ix = (int)Math.Round((x - w_xmin) /
                        w_wid * pboxGraph.ClientSize.Width);
                    iy = (int)Math.Round(
                        (pboxGraph.ClientSize.Height - 1) -
                        (y - w_ymin) / w_hgt * hgt);
                    if ((ix >= 0) && (iy >= 0) &&
                        (ix < wid) && (iy < hgt))
                    {
                        bm.SetPixel(ix, iy, Color.Black);
                    }
                }
            }

            // Display the result.
            pboxGraph.Image = bm;
        }


        // make snowflake methods (& vars)

        // coords of points in Initiator
        private List<PointF> Initiator;

        // angles & distances for the generator
        private float ScaleFactor;
        private List<float> GeneratorDTheta;

        private void btnSnowflake_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // define the initiator & generator
            Initiator = new List<PointF>();
            float height = 0.75f * (Math.Min(
                pboxGraph.ClientSize.Width,
                pboxGraph.ClientSize.Height) - 20);
            float width = (float)(height / Math.Sqrt(3.0) * 2);
            float y3 = pboxGraph.ClientSize.Height - 10;
            float y1 = y3 - height;
            float x3 = pboxGraph.ClientSize.Height / 2;
            float x1 = x3 - width / 2;
            float x2 = x1 + width;
            Initiator.Add(new PointF(x1, y1));
            Initiator.Add(new PointF(x2, y1));
            Initiator.Add(new PointF(x3, y3));
            Initiator.Add(new PointF(x1, y1));

            ScaleFactor = 1 / 3f;                   // make the sub-segments a third of the size

            GeneratorDTheta = new List<float>();
            float pi_over_3 = (float)(Math.PI / 3f);
            GeneratorDTheta.Add(0);                 // draw in the original direction, then
            GeneratorDTheta.Add(-pi_over_3);        // turn -60 degrees, then
            GeneratorDTheta.Add(2 * pi_over_3);     // turn 120 degrees, then
            GeneratorDTheta.Add(-pi_over_3);        // turn -60 degrees

            // get the parameters
            int depth = tbarDepth.Value;

            Bitmap bm = new Bitmap(pboxGraph.ClientSize.Width, pboxGraph.ClientSize.Height);
            pboxGraph.Image = bm;

            // draw the snowflake
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                DrawSnowflake(gr, depth);
            }

            this.Cursor = Cursors.Default;
        }

        // draw the complete snowflake
        private void DrawSnowflake(Graphics gr, int depth)
        {
            gr.Clear(pboxGraph.BackColor);

            // draw the snowflake
            for (int i = 1; i < Initiator.Count; i++)
            {
                PointF p1 = Initiator[i - 1];
                PointF p2 = Initiator[i];

                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;
                float length = (float)Math.Sqrt(dx * dx + dy * dy);
                float theta = (float)Math.Atan2(dy, dx);
                DrawSnowflakeEdge(gr, depth, ref p1, theta, length);
            }
        }

        // recursively draw a snowflake, starting at (1, 1), in dir. theta and distance dist.; leave coords of the endpoint at (1, 1)
        private void DrawSnowflakeEdge(Graphics gr, int depth, ref PointF p1, float theta, float dist)
        {
            if (depth == 0)
            {
                PointF p2 = new PointF(
                    (float)(p1.X + dist * Math.Cos(theta)),
                    (float)(p1.Y + dist * Math.Sin(theta)));
                Pen p = new Pen(Color.Black, 1);
                gr.DrawLine(p, p1, p2);
                p1 = p2;
                return;
            }

            // Recursively draw the edge.
            dist *= ScaleFactor;
            for (int i = 0; i < GeneratorDTheta.Count; i++)
            {
                theta += GeneratorDTheta[i];
                DrawSnowflakeEdge(gr, depth - 1, ref p1, theta, dist);
            }
        }

        private void btnFern_Click(object sender, EventArgs e)
        {
            MakeFern();
        }
    }
}
