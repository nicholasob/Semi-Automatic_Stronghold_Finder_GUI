using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using Tesseract;

namespace Stronghold_Finder
{
    public partial class Form1 : Form
    {
        //Global variables
        //The title of the game window, chose to have the option to select as the game window name might change with updates.
        string WindowTitle;

        //The maximum and minumum for the chart axis.
        int currentMaximum, currentMinimum;
        
        //The current estimated stronghold position.
        double[] strongHoldCoordinates = { -1, -1 };
        
        //The rings the stronghold can be whitin.
        readonly int[][] strongHold_radius = { new int[]{ 1280, 2816 }, new int[] { 4352, 5888 }, new int[] { 7424, 8960 }, new int[] { 10496, 12032 }, new int[] { 13568, 15104 }, new int[] { 16640, 18176 }, new int[] { 19712, 21248 }, new int[] { 22784, 24320 } };
        
        //The hotkey used by the player.
        Keys keyCode;
        
        //The following Bitmap is used when the user wants to modify the crop values.
        Bitmap savedImageForSetup;
        
        //The following variable is used for drawing the rings on chart, the Paint function.
        short paintIndex;
        
        //The width and height of the chart, used as the chart likes to jump around when the label text grows in size. 
        double chartAreaWidth, chartAreaHeight;
        
        //If the user wants to use percentage or pixels, 1 (true) = percentage and 0 (false) = pixels. 
        bool coordsPercentageOrPixels, anglePercentageOrPixels;
        
        //Consists of double arrays, where the two first indexes is the users position when throwing an eye and the last index being the angle.
        List<double[]> arrayOfUsages = new List<double[]>();
        
        //The path for both the XML file (saves the users current settings) and the custom trained data.
        string XMLPath = "./DATA/VALUES.xml";
        string tessdata = "./tessdata/";
        Screenshot sc = new Screenshot();
        private IKeyboardMouseEvents m_GlobalHook;

        //Used for creating new lines
        int AMOUNT_OF_LINES;
        
        //Check if the user wants to modify the values
        bool modifyChecked;

        //private void reset_Everything()
        //{
        //    currentMaximum = 3000;
        //    currentMinimum = currentMaximum * -1;
        //    strongHoldCoordinates = new double[]{ -1, -1};
        //    arrayOfUsages.Clear();
        //    AMOUNT_OF_INTEGERS = 0;
        //    chart1.Series.Clear();
        //    create_hori_verti_line(ref chart1);
        //    chart1.Invalidate();
        //    IsRunningText.Text = "NOT Running";
        //    IsRunningText.ForeColor = Color.Red;
        //    positionUpdate.Stop();
        //}

        public Form1()
        {
            InitializeComponent();

        }
        /// <summary>
        /// The following function is called in the beginning of the software, it initilizes everything. 
        /// </summary>
        private void init_State()
        {
            currentMaximum = 3000;
            currentMinimum = currentMaximum * -1;

            chart1.Series.Clear();
            AMOUNT_OF_LINES = 0;
            create_hori_verti_line(ref chart1);
            foreach (Keys key in (Keys[])Enum.GetValues(typeof(Keys)))
            {
                if (!comboBox1.Items.Contains(key))
                {
                    comboBox1.Items.Add(key);
                }
            }
            init_XML_Values();

            //EnableDisableAllControls(false);
            chart1.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
            chart1.ChartAreas[0].AxisY.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;

            chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            chart1.ChartAreas[0].AxisY.IsLabelAutoFit = false;

            chart1.ChartAreas[0].Position.Y = 10;
            chart1.ChartAreas[0].Position.Height = 85;
            chart1.ChartAreas[0].Position.X = 5;
            chart1.ChartAreas[0].Position.Width = 75;

            chart1.ChartAreas[0].Position.Auto = false;
            chart1.ChartAreas[0].IsSameFontSizeForAllAxes = true;

            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            chart1.ChartAreas[0].AxisY.IsMarginVisible = false;

            chart1.Update();
            //Console.WriteLine("ab " + );
        }

        /// <summary>
        /// The following function assign and saves the window title the user has chosen. 
        /// </summary>
        /// <param name="str">The name of the window title</param>
        /// <param name="saveCondition">set the condition to True if you want to save or False if you don't.</param>
        public void setWindowTitle(string str, bool saveCondition)
        {
            this.label2.Text = str;
            this.WindowTitle = str;
            //If the game title should be saved.
            if (saveCondition)
            {
                XmlDocument doc = new XmlDocument() { XmlResolver = null };

                doc.Load(XMLPath);
                doc.SelectSingleNode("values/game/TITLE").InnerText = str;

                doc.Save(XMLPath);

            }
        }
        /// <summary>
        /// Innitilizing all the values depending on the users XML file. 
        /// </summary>
        private void init_XML_Values()
        {
            XmlDocument doc = new XmlDocument() { XmlResolver = null };
            doc.Load(XMLPath);

            coordsPercentageOrPixels = toBoolean(doc.SelectSingleNode("values/mode/CORDS").InnerText);
            anglePercentageOrPixels = toBoolean(doc.SelectSingleNode("values/mode/ANGLE").InnerText);
            //Settings used are in percentage
            if (coordsPercentageOrPixels == true)
            {
                setNumericBoxes(GroupBox_Coordinates, 0.001M, 3, 1);
                X_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/X").InnerText);
                Y_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/Y").InnerText);
                WIDTH_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/WIDTH").InnerText);
                HEIGHT_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/HEIGHT").InnerText);
            }
            //Settings used are in pixels
            else
            {
                setNumericBoxes(GroupBox_Coordinates, 1, 0, 10000);
                X_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/X").InnerText);
                Y_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/Y").InnerText);
                WIDTH_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/WIDTH").InnerText);
                HEIGHT_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/HEIGHT").InnerText);
            }
            //Settings used are in percentage
            if (anglePercentageOrPixels == true)
            {
                setNumericBoxes(GroupBox_Angle, 0.001M, 3, 1);
                X_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/X").InnerText);
                Y_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/Y").InnerText);
                WIDTH_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/WIDTH").InnerText);
                HEIGHT_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/HEIGHT").InnerText);
            }
            //Settings used are in pixels
            else
            {
                //the following function
                setNumericBoxes(GroupBox_Angle, 1, 0, 10000);
                X_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/X").InnerText);
                Y_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/Y").InnerText);
                WIDTH_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/WIDTH").InnerText);
                HEIGHT_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/HEIGHT").InnerText);
            }

            comboBox1.SelectedIndex = int.Parse(doc.SelectSingleNode("values/button/savedkey").InnerText);
            setWindowTitle(doc.SelectSingleNode("values/game/TITLE").InnerText, false);
    }
        

        /// <summary>
        /// This function is currently only called when the process starts. It gets the second closest stronghold ring from the player and updates the graph
        /// </summary>
        /// <param name="cx1">The players current X-Position.</param>
        /// <param name="cz1">The players current Z-Position.</param>
        private void getClosestCircleFromPosition(int cx1, int cz1)
        {
            //Makes sure the passed variable is positive.
            if (cx1 < 0) cx1 = cx1 * -1;
            if (cz1 < 0) cz1 = cz1 * -1;

            //Gets the biggest value of the two passed parameters.
            int biggestValue = (cx1 > cz1) ? cx1 : cz1;

            //Iterate through all the stronghold ring ranges.
            for(short x = 0; x < strongHold_radius.Length - 1; ++x)
            {
                //If the players position is inside/within the stronghold ring.
                if(biggestValue < strongHold_radius[x][0])
                {
                    //The following variable is used for the graph/chart. Uses the next circle to ensure the stronghold is rendered if it is inside the next ring. 
                    int ValueToUse = strongHold_radius[x + 1][1] + 1000 - strongHold_radius[x + 1][1] % 1000;
                    
                    //If the players position is new and not within the current rendered ring, then re-render everything.
                    if (ValueToUse != currentMaximum)
                    {
                        currentMaximum = ValueToUse;
                        currentMinimum = currentMaximum * -1;
                        paintIndex = (short)(x + 1);
                        create_hori_verti_line(ref chart1);
                        chart1.Invalidate();
                    }
                    break;
                }
            }
        }
        /// <summary>
        /// The following function adds a new line to the chart with a custom name.
        /// </summary>
        /// <param name="c">The current Chart object to use.</param>
        /// <param name="s">Custom name of the new line to add.</param>
        /// <param name="cx1">The players current X-position.</param>
        /// <param name="cz1">The players current Z-position.</param>
        /// <param name="cxS">The strongholds X-position.</param>
        /// <param name="czS">The strongholds Z-position.</param>
        private void addLineToChartCustom(ref Chart c, string s, int cx1, int cz1, int cxS, int czS)
        {
            string getNameOfTheNewLine = s;

            c.Series.Add(getNameOfTheNewLine);

            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cx1, cz1));
            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cxS, czS));

            c.Series[getNameOfTheNewLine].ChartType = SeriesChartType.Line;
        }

        /// <summary>
        /// The following function adds a new line to the chart.
        /// </summary>
        /// <param name="c">The current Chart object to use.</param>
        /// <param name="cx1">The players current X-position.</param>
        /// <param name="cz1">The players current Z-position.</param>
        /// <param name="cxS">The strongholds X-position.</param>
        /// <param name="czS">The strongholds Z-position.</param>
        private void addLineToChart(ref Chart c, int cx1, int cz1, int cxS, int czS)
        {
            string getNameOfTheNewLine = "stronghold_line_" + AMOUNT_OF_LINES.ToString();

            c.Series.Add(getNameOfTheNewLine);

            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cx1, cz1));
            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cxS, czS));

            c.Series[getNameOfTheNewLine].ChartType = SeriesChartType.Line;

            AMOUNT_OF_LINES++;
        }

        /// <summary>
        /// The following function adds a new line to the chart.
        /// </summary>
        /// <param name="c">The current Chart object to use.</param>
        /// <param name="c1">The players current position.</param>
        /// <param name="cS">The strongholds position.</param>
        private void addLineToChart(ref Chart c, int[] c1, int[] cS)
        {
            string getNameOfTheNewLine = "stronghold_line_" + AMOUNT_OF_LINES.ToString();

            c.Series.Add(getNameOfTheNewLine);

            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(c1[0], c1[1]));
            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cS[0], cS[1]));

            c.Series[getNameOfTheNewLine].ChartType = SeriesChartType.Line;

            AMOUNT_OF_LINES++;
        }
        /// <summary>
        /// The following function adds a new line to the chart with a custom DashStyle.
        /// </summary>
        /// <param name="c">The current Chart object to use.</param>
        /// <param name="DashStyle">Custom line dashstyle.</param>
        /// <param name="cx1">The players current X-position.</param>
        /// <param name="cz1">The players current Z-position.</param>
        /// <param name="cxS">The strongholds X-position.</param>
        /// <param name="czS">The strongholds Z-position.</param>
        private void addLineToChart(ref Chart c, string name, ChartDashStyle DashStyle, int cx1, int cz1, int cxS, int czS)
        {
            string getNameOfTheNewLine = name;

            c.Series.Add(getNameOfTheNewLine);

            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cx1, cz1));
            c.Series[getNameOfTheNewLine].Points.Add(new DataPoint(cxS, czS));

            c.Series[getNameOfTheNewLine].ChartType = SeriesChartType.Line;

            c.Series[getNameOfTheNewLine].BorderDashStyle = DashStyle;
            c.Series[getNameOfTheNewLine].BorderWidth = 2;

        }

        /*
        /// <summary>
        /// Either disables or enables all the controls on the form for an exception of getWindow and timeInterval.
        /// </summary>
        /// <param name="status">False to disable and true to enable all controls.</param>
        void EnableDisableAllControls(bool status)
        {
            foreach (Control control in this.Controls)
            {
                Console.WriteLine(control.Name);
                if (control is GroupBox)
                {
                    foreach (Control controls in control.Controls)
                    {
                        //Exception for these two controls, getWindow and timeInterval.
                        if (controls.Name != "getWindow" && controls.Name != "timeInterval")
                        {
                            controls.Enabled = status;
                        }
                    }
                }
                else
                {
                    control.Enabled = status;
                }
            }
        }
        */

        /// <summary>
        /// Update both Axis X and Axis Y's values.
        /// </summary>
        /// <param name="c">The chart element to use</param>
        private void update_Axis_Width_Height(ref Chart c)
        {
            c.ChartAreas[0].AxisX.Maximum = currentMaximum;
            c.ChartAreas[0].AxisY.Maximum = currentMaximum;

            c.ChartAreas[0].AxisX.Minimum = currentMinimum;
            c.ChartAreas[0].AxisY.Minimum = currentMinimum;
        }

        /// <summary>
        /// The following function creates the horizontal and vertical lines. 
        /// </summary>
        /// <param name="c">The chart element to use.</param>
        private void create_hori_verti_line(ref Chart c)
        {
            update_Axis_Width_Height(ref c);

            c.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;
            c.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;

            if (!(c.Series.IsUniqueName("Horizontal-Line") || c.Series.IsUniqueName("Vertical-Line")))
            {
                c.Series.Remove(c.Series["Horizontal-Line"]);
                c.Series.Remove(c.Series["Vertical-Line"]);
            }
            addLineToChartCustom(ref c, "Horizontal-Line", currentMinimum, 0, currentMaximum, 0);
            addLineToChartCustom(ref c, "Vertical-Line", 0, currentMinimum, 0, currentMaximum);
            c.Series["Horizontal-Line"].BorderWidth = 3;
            c.Series["Vertical-Line"].BorderWidth = 3;
        }

        /// <summary>
        /// The following function is frequently used/called to validate if the graph should be updated and re-drawn.
        /// </summary>
        /// <param name="c">The current chart object, passed by refference</param>
        /// <param name="currentStrongholdXPos">The predicted stronghold X-position</param>
        /// <param name="currentStrongholdZPos">The predicted stronghold Z-position</param>
        private void update_New_Graph(ref Chart c, int currentStrongholdXPos, int currentStrongholdZPos)
        {
            //The following variable will be used later on.
            int ValueToUse;
            //Iteration through all the stronghold rings.
            for (short index = 0; index < strongHold_radius.GetLength(0); ++index) {
                //If the coordinates is whithin the outer ring.
                bool isInsideOuterRing = ((Math.Pow(currentStrongholdXPos, 2) + Math.Pow(currentStrongholdZPos, 2)) <= (Math.Pow(strongHold_radius[index][1],2))) ? true : false;
                //If the coordinates is whithin the inner ring.
                bool isInsideInnerRing = ((Math.Pow(currentStrongholdXPos, 2) + Math.Pow(currentStrongholdZPos, 2)) <= (Math.Pow(strongHold_radius[index][0], 2))) ? true : false;
                //Checks if the stronghold is within the specific ring
                if (isInsideOuterRing && !isInsideInnerRing)
                {
                    ValueToUse = strongHold_radius[index][1] + 1000 - strongHold_radius[index][1] % 1000;
                    if(ValueToUse != currentMaximum)
                    {
                        currentMaximum = ValueToUse;
                        currentMinimum = ValueToUse * -1;
                        chart1.ChartAreas[0].AxisX.Interval = currentMaximum / 3;
                        chart1.ChartAreas[0].AxisY.Interval = currentMaximum / 3;
                        paintIndex = index;
                        create_hori_verti_line(ref c);
                        c.Invalidate();
                    }
                }
            }
        }

        /// <summary>
        /// Saves the inputed values to the XML file for future uses.
        /// </summary>
        /// <param name="b">This indicates which button this function was called from.</param>
        private void set_XML_Values(ref Button b)
        {
            XmlDocument doc = new XmlDocument() { XmlResolver = null };

            doc.Load(XMLPath);

            if (b == SAVE_Coordinates)
            {
                if (coordsPercentageOrPixels == true)
                {
                    doc.SelectSingleNode("values/coordinate_percentage/X").InnerText = X_coordinate.Value.ToString();
                    doc.SelectSingleNode("values/coordinate_percentage/Y").InnerText = Y_coordinate.Value.ToString();
                    doc.SelectSingleNode("values/coordinate_percentage/WIDTH").InnerText = WIDTH_coordinate.Value.ToString();
                    doc.SelectSingleNode("values/coordinate_percentage/HEIGHT").InnerText = HEIGHT_coordinate.Value.ToString();
                }
                else
                {
                    doc.SelectSingleNode("values/coordinate/X").InnerText = X_coordinate.Value.ToString();
                    doc.SelectSingleNode("values/coordinate/Y").InnerText = Y_coordinate.Value.ToString();
                    doc.SelectSingleNode("values/coordinate/WIDTH").InnerText = WIDTH_coordinate.Value.ToString();
                    doc.SelectSingleNode("values/coordinate/HEIGHT").InnerText = HEIGHT_coordinate.Value.ToString();
                }
            }
            else if (b == SAVE_Angles)
            {
                if (anglePercentageOrPixels == true)
                {
                    doc.SelectSingleNode("values/angle/X").InnerText = X_angle.Value.ToString();
                    doc.SelectSingleNode("values/angle/Y").InnerText = Y_angle.Value.ToString();
                    doc.SelectSingleNode("values/angle/WIDTH").InnerText = WIDTH_angle.Value.ToString();
                    doc.SelectSingleNode("values/angle/HEIGHT").InnerText = HEIGHT_angle.Value.ToString();
                }
                else
                {
                    doc.SelectSingleNode("values/angle_percentage/X").InnerText = X_angle.Value.ToString();
                    doc.SelectSingleNode("values/angle_percentage/Y").InnerText = Y_angle.Value.ToString();
                    doc.SelectSingleNode("values/angle_percentage/WIDTH").InnerText = WIDTH_angle.Value.ToString();
                    doc.SelectSingleNode("values/angle_percentage/HEIGHT").InnerText = HEIGHT_angle.Value.ToString();
                }
            }
            doc.Save(XMLPath);
          
        }

        /// <summary>
        /// Parsing the angle string that Sellenium fatches from the cropped screenshot. 
        /// </summary>
        /// <param name="STRING">The string of the angle</param>
        /// <returns></returns>
        private double parseAngle(string STRING)
        {
            string SplittedString = STRING.Split('/')[0].Replace(".", ",");
            return double.Parse(SplittedString.Substring(SplittedString.IndexOf('(') + 1).Trim());
        }
        /// <summary>
        /// Parsing the position string that Sellenium fatches from the cropped screenshot. 
        /// </summary>
        /// <param name="STRING">The string of the coordinates</param>
        /// <returns></returns>
        private double[] parseCoordinates(string STRING)
        {
            string[] SplittedString = STRING.Replace(".", ",").Split('/');
            SplittedString[0] = SplittedString[0].Replace("XYZ:", "");
            return new double[] {Double.Parse(SplittedString[0].Trim()), Double.Parse(SplittedString[1].Trim()), Double.Parse(SplittedString[2].Trim()) };
        }
        /// <summary>
        /// The "main" function in this program and is called when the user presses the hotkey. 
        /// </summary>
        private void takeScreenshot()
        {
            //Screenshot of the whole game window
            var minecraft_window = sc.ScreenShotWindowName(WindowTitle);
            

            //If the taken screenshot gets returned null, then set the Status label and return.
            if (minecraft_window == null)
            {
                Status.Text = "Check your game window!";
                return;
            }

            //The X and Y Coordinate
            double[] coords = { 0, 0, 0};
            double Angle = 0;

            //These are the cropped iamges from tha game window, "CoordsCroppedImage" is the coordinates and "AngleCroppedImage" is the angle.
            //using (Bitmap croppedImage = MCImage.CropImage(minecraft_window, (X_coordinate.Value), (Y_coordinate.Value), (WIDTH_coordinate.Value), (HEIGHT_coordinate.Value), coordsPercentageOrPixels))
            //using (Bitmap CoordsCroppedImage = MCImage.getBlackWhiteImage(MCImage.CropImage(minecraft_window, (X_coordinate.Value), (Y_coordinate.Value), (WIDTH_coordinate.Value), (HEIGHT_coordinate.Value), coordsPercentageOrPixels)))
            //Using tesseract and a custom made language pack i made for the minecraft font to work. The "minecraft" language file is trained for coordinates.
            using(Bitmap croppedImage = MCImage.CropImage(minecraft_window, (X_coordinate.Value), (Y_coordinate.Value), (WIDTH_coordinate.Value), (HEIGHT_coordinate.Value), coordsPercentageOrPixels))
            using(Bitmap CoordsCroppedImage = MCImage.getBlackWhiteImage(croppedImage))
            using(TesseractEngine tesseract_reader = new TesseractEngine(tessdata, "minecraft"))
            {
                Page Coordspage = tesseract_reader.Process(CoordsCroppedImage);
                string CoordsText = Coordspage.GetText();

                Coordspage.Dispose();
                if (!string.IsNullOrEmpty(CoordsText))
                {
                    coords = parseCoordinates(CoordsText);
                    //Sets the label to show the players current position and angle (when pressing the hotkey).
                    label12.Text = "X: " + coords[0].ToString() + ", Y: " + coords[1].ToString() + ", Z: " + coords[2].ToString();
                }
                else
                {
                    if(modifyChecked == false)
                    {
                        Status.Text = "Check if Debug (f3) is open!";
                        return;
                    }
                }
            }


            //Using tesseract and a custom made language pack i made for the minecraft font to work. The "minecraftangle" language file is trained for reading the angle.
            using (Bitmap croppedImage = MCImage.CropImage(minecraft_window, (X_angle.Value), (Y_angle.Value), (WIDTH_angle.Value), (HEIGHT_angle.Value), anglePercentageOrPixels))
            using (Bitmap AngleCroppedImage = MCImage.getBlackWhiteImage(croppedImage))
            using (TesseractEngine tesseract_reader_angle = new TesseractEngine(tessdata, "minecraftangle"))
            {
                Page Anglepage = tesseract_reader_angle.Process(AngleCroppedImage);

                string AngleText = Anglepage.GetText();
                Anglepage.Dispose();

                if (!string.IsNullOrEmpty(AngleText))
                {
                    Angle = parseAngle(AngleText);
                    //Sets the label to show the players current position and angle (when pressing the hotkey).
                    label13.Text = Angle.ToString();

                }
                else
                {
                    if (modifyChecked == false)
                    {
                        Status.Text = "Check if Debug (f3) is open!";
                        return;
                    }
                }
            }
   

            //Appending the players position and angle to the list of double arrays.
            arrayOfUsages.Add(new double[] { coords[0], coords[2], Angle });

            //If the player has pressed the hotkey more then 1 time, then execute the following.
            if (arrayOfUsages.Count > 1)
            {
                strongHoldCoordinates = Stronghold.getStrongholdCoords(arrayOfUsages[arrayOfUsages.Count - 2], arrayOfUsages[arrayOfUsages.Count - 1]);
                int strongHoldXCasted = ((int)strongHoldCoordinates[0]);
                int strongHoldZCasted = ((int)strongHoldCoordinates[1]);

                label18.Text = "X: " + strongHoldXCasted.ToString() + ", Z: " + strongHoldZCasted.ToString();

                update_New_Graph(ref chart1, strongHoldXCasted, strongHoldZCasted);
                addLineToChart(ref chart1, (int)arrayOfUsages[arrayOfUsages.Count - 1][0], (int)arrayOfUsages[arrayOfUsages.Count - 1][1], strongHoldXCasted, strongHoldZCasted);
                label20.Text = ((int)Stronghold.distanceBetweenTwoPoints(coords[0], coords[2], strongHoldXCasted, strongHoldZCasted)).ToString();


                if (chart1.Series.IndexOf("destination") != -1)
                {
                    chart1.Series["destination"].Points.Clear();
                }
                else
                {
                    chart1.Series.Add("destination");
                }
                chart1.Series["destination"].MarkerStyle = MarkerStyle.Cross;
                chart1.Series["destination"].BorderWidth = 2;
                chart1.Series["destination"].Points.Add(new DataPoint(strongHoldCoordinates[0], strongHoldCoordinates[1]));
                chart1.Series["destination"].Color = Color.Red;

            }
            //If this is the first hotkey press, then do standard things. 
            else
            {
                Destination.Text = "Not there!";
                Destination.ForeColor = Color.Red;

                chartAreaWidth = chart1.ChartAreas[0].Position.Width;
                chartAreaHeight = chart1.ChartAreas[0].Position.Height;


                int x = (int)arrayOfUsages[arrayOfUsages.Count - 1][0], z = (int)arrayOfUsages[arrayOfUsages.Count - 1][1];
                getClosestCircleFromPosition(x, z);

                //If the player wants to modify the values, then do the following
                if (modifyChecked == true)
                {
                    savedImageForSetup = MCImage.getBlackWhiteImage((Bitmap)minecraft_window);
                    //This makes sure that the timer dosen't start in case the user accidantly enabled it. (this would put minecraft in the foreground at each interval).
                    Status.Text = "Press 'Preview Image' and adjust.";
                    minecraft_window.Dispose();
                    return;
                }

                //If the player has enabled for realtime position update, then do the following.
                if (Position_Update.CheckState == CheckState.Checked)
                {
                    //The following variable will be used for the reference line. Gives the player knowledge if they are heading in the right direction.
                    int distance = 4000;
                    double ANGLE = Angle % 360;
                    if (ANGLE >= 0)
                    {
                        ANGLE = (ANGLE + 90) % 360;
                    }
                    else
                    {
                        ANGLE = (ANGLE - 270) % 360;
                    }
                    ANGLE = (ANGLE * Math.PI / 180.0);

                    addLineToChart(ref chart1, "REFERENCE_LINE", ChartDashStyle.Dash, x, z, (int)(x + Math.Cos(ANGLE) * distance), (int)(z + Math.Sin(ANGLE) * distance));

                    //Makes sure that the timer isn't already enabled.
                    if (positionUpdate.Enabled == false)
                    {
                        //starts the timer, which will update the persons position in real time and translate it to the graph. 
                        positionUpdate.Start();
                    }

                }
            }
            Status.Text = "";
            minecraft_window.Dispose();
            
        }

        //Opens the form/window that lists the processes named "minecraft".
        private void getWindow_Click(object sender, EventArgs e)
        {
            windowList w = new windowList(this);
            w.Show();

            //EnableDisableAllControls(true);


        }
        //Starts the process to read the players position.
        public void Subscribe()
        {

            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyDown += GlobalHookKeyPress;
        }
        //The function that is called each time the player presses.
        private void GlobalHookKeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == keyCode)
            {
                takeScreenshot();
            }
        }
        //Stops the process to read the players position.
        public void Unsubscribe()
        {
 
            m_GlobalHook.KeyDown -= GlobalHookKeyPress;

            m_GlobalHook.Dispose();
        }


        //The checkbox that enables automatic position update.
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(Position_Update.CheckState == CheckState.Checked)
            {
                timeInterval.Enabled = true;
            }
            else
            {
                timeInterval.Enabled = false;
                if (positionUpdate.Enabled == true)
                {
                    positionUpdate.Stop();

                }
            }
        }
        //Changes the timerinterval for the timer
        private void timeInterval_ValueChanged(object sender, EventArgs e)
        {
            positionUpdate.Interval = (Decimal.ToInt32(timeInterval.Value)*1000);
        }

        //Button that saves the edited coordinate values to the xml file
        private void SAVE_Coordinates_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Update comfirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                set_XML_Values(ref SAVE_Coordinates);
            }
            //...
        }

        //Button that saves the edited angle values to the xml file
        private void SAVE_Angles_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Update comfirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                set_XML_Values(ref SAVE_Angles);
            }
        }


        //The button that previews the coordinates.
        private void Preview_Coordinates_Click(object sender, EventArgs e)
        {
            var minecraft_window = sc.ScreenShotWindowName(WindowTitle);
            Bitmap Coords = MCImage.CropImage(minecraft_window, (X_coordinate.Value), (Y_coordinate.Value), (WIDTH_coordinate.Value), (HEIGHT_coordinate.Value),coordsPercentageOrPixels);
            var formsList = Application.OpenForms.OfType<showImage>().ToArray();
            
            if (formsList.Length > 0)
            {
                formsList.ToArray()[0].setImagePic(Coords);
            }
            else
            {
                showImage sI = new showImage(Coords, minecraft_window.Width, minecraft_window.Height);

                sI.Show();

            }
            minecraft_window.Dispose();
        }
        //The button that previews the angle 
        private void Preview_Angle_Click(object sender, EventArgs e)
        {
            Image minecraft_window = sc.ScreenShotWindowName(WindowTitle);
            Bitmap Angle = MCImage.CropImage(minecraft_window,(X_angle.Value), (Y_angle.Value), (WIDTH_angle.Value), (HEIGHT_angle.Value), anglePercentageOrPixels);
            var formsList = Application.OpenForms.OfType<showImage>().ToArray();

            if (formsList.Length > 0)
            {
                formsList.ToArray()[0].setImagePic(Angle);
            }
            else
            {
                showImage sI = new showImage(Angle, minecraft_window.Width, minecraft_window.Height);
                
                sI.Show();
                
            }
            minecraft_window.Dispose();
        }

        //The timer tick that will update the players position on the graph.
        private void positionUpdate_Tick(object sender, EventArgs e)
        {
            Image minecraft_window = sc.ScreenShotWindowName(WindowTitle);
            int timeInterval = ((positionUpdate.Interval /1000) * 10);
            if (minecraft_window == null)
            {
                return;
            }
            double[] coords;
            using (Bitmap croppedImage = MCImage.CropImage(minecraft_window, (X_coordinate.Value), (Y_coordinate.Value), (WIDTH_coordinate.Value), (HEIGHT_coordinate.Value), coordsPercentageOrPixels))
            using (Bitmap Coords = MCImage.getBlackWhiteImage(croppedImage))
            using (TesseractEngine tesseract_reader = new TesseractEngine(tessdata, "minecraft")) { 

                Page Coordspage = tesseract_reader.Process(Coords);
                string CoordsText = Coordspage.GetText();

                if (!string.IsNullOrEmpty(CoordsText))
                {
                    coords = parseCoordinates(CoordsText);
                    double distance = Stronghold.distanceBetweenTwoPoints(coords[0], coords[2], strongHoldCoordinates[0], strongHoldCoordinates[1]);

                    if (chart1.Series.IndexOf("position") != -1)
                    {
                        chart1.Series["position"].Points.Clear();
                    }
                    else
                    {
                        chart1.Series.Add("position");
                    }
                    chart1.Series["position"].MarkerStyle = MarkerStyle.Cross;
                    chart1.Series["position"].Points.Add(new DataPoint(coords[0], coords[2]));
                    chart1.Series["position"].Color = Color.Purple;
                    if (distance > timeInterval)
                    {
                        label20.Text = ((int)distance).ToString();
                    }
                    else
                    {
                        if (distance == -1) return;

                        positionUpdate.Stop();
                        label20.Text = "Whitin " + timeInterval.ToString() + " blocks!";

                        Destination.Text = "You are " + ((int)distance).ToString() + " blocks from destination!";
                        Destination.ForeColor = Color.Green;
                    }

                }
                Coordspage.Dispose();
       
            }
            minecraft_window.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            init_State();
        }

        private void setNumericBoxes(GroupBox gb, Decimal Increment, Int32 DecimalPlaces, int MaxRange)
        {
            foreach(var Item in gb.Controls.OfType<NumericUpDown>())
            {
                Item.Increment = Increment;
                Item.DecimalPlaces = DecimalPlaces;
                Item.Maximum = MaxRange;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument() { XmlResolver = null };

            doc.Load(XMLPath);

            doc.SelectSingleNode("values/button/savedkey").InnerText = comboBox1.SelectedIndex.ToString();

            doc.Save(XMLPath);
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private bool toBoolean(string str)
        {
            return (str == "1") ? true : false;
        }

        private void Switch(Button b)
        {
            XmlDocument doc = new XmlDocument() { XmlResolver = null };

            doc.Load(XMLPath);

            if (b == Swich_Coords)
            {

                if (coordsPercentageOrPixels == false)
                {
                    setNumericBoxes(GroupBox_Coordinates, 0.001M, 3, 1);

                    X_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/X").InnerText);
                    Y_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/Y").InnerText);
                    WIDTH_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/WIDTH").InnerText);
                    HEIGHT_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate_percentage/HEIGHT").InnerText);

                    coordsPercentageOrPixels = true;
                    doc.SelectSingleNode("values/mode/CORDS").InnerText = "1";
                }
                else
                {
                    setNumericBoxes(GroupBox_Coordinates, 1, 0, 10000);

                    X_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/X").InnerText);
                    Y_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/Y").InnerText);
                    WIDTH_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/WIDTH").InnerText);
                    HEIGHT_coordinate.Value = Decimal.Parse(doc.SelectSingleNode("values/coordinate/HEIGHT").InnerText);

                    coordsPercentageOrPixels = false;
                    doc.SelectSingleNode("values/mode/CORDS").InnerText = "0";
                }
            }
            else if (b == Swich_Angle)
            {

                if (anglePercentageOrPixels == false)
                {
                    setNumericBoxes(GroupBox_Angle, 0.001M, 3, 1);

                    X_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/X").InnerText);
                    Y_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/Y").InnerText);
                    WIDTH_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/WIDTH").InnerText);
                    HEIGHT_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle_percentage/HEIGHT").InnerText);

                    anglePercentageOrPixels = true;
                    doc.SelectSingleNode("values/mode/ANGLE").InnerText = "1";
                }
                else
                {
                    setNumericBoxes(GroupBox_Angle, 1, 0, 10000);

                    X_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/X").InnerText);
                    Y_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/Y").InnerText);
                    WIDTH_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/WIDTH").InnerText);
                    HEIGHT_angle.Value = Decimal.Parse(doc.SelectSingleNode("values/angle/HEIGHT").InnerText);

                    anglePercentageOrPixels = false;
                    doc.SelectSingleNode("values/mode/ANGLE").InnerText = "0";
                }
            }

            doc.Save(XMLPath);
        }
        

        private void Swich_Angle_Click(object sender, EventArgs e)
        {
            Switch(Swich_Angle);
        }

        private void Preview_Image_Coords_Click(object sender, EventArgs e)
        {
            if (savedImageForSetup == null) return;
            Bitmap Coords = MCImage.CropImage(savedImageForSetup, (X_coordinate.Value), (Y_coordinate.Value), (WIDTH_coordinate.Value), (HEIGHT_coordinate.Value), coordsPercentageOrPixels);
            var formsList = Application.OpenForms.OfType<showImage>().ToArray();

            using (TesseractEngine tesseract_reader = new TesseractEngine(tessdata, "minecraft"))
            {
                Page Coordspage = tesseract_reader.Process(Coords);
                string CoordsText = Coordspage.GetText();
                if (formsList.Length > 0)
                {
                    formsList.ToArray()[0].setImagePic(Coords);
                    formsList.ToArray()[0].ConvertedText.Text = CoordsText;
                }
                else
                {
                        showImage sI = new showImage(Coords, savedImageForSetup.Width, savedImageForSetup.Height);
                    
                        sI.Show();
                        sI.ConvertedText.Text = CoordsText;
                }
                Coordspage.Dispose();
            }
        }

        private void Preview_Image_Angle_Click(object sender, EventArgs e)
        {
            if (savedImageForSetup == null) return;
            Bitmap Angle = MCImage.CropImage(savedImageForSetup, (X_angle.Value), (Y_angle.Value), (WIDTH_angle.Value), (HEIGHT_angle.Value), anglePercentageOrPixels);
            var formsList = Application.OpenForms.OfType<showImage>().ToArray();

            using (TesseractEngine tesseract_reader_angle = new TesseractEngine(tessdata, "minecraftangle"))
            {
                Page Anglepage = tesseract_reader_angle.Process(Angle);
                string AngleText = Anglepage.GetText();

                if (formsList.Length > 0)
                {
                    formsList.ToArray()[0].setImagePic(Angle);
                    formsList.ToArray()[0].ConvertedText.Text = AngleText;
                }
                else
                {
                    showImage sI = new showImage(Angle, savedImageForSetup.Width, savedImageForSetup.Height);
                    sI.Show();
                    sI.ConvertedText.Text = AngleText;
                }
                Anglepage.Dispose();
            }
        }

        //The function that starts everything! :)
        private void START_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && !string.IsNullOrEmpty(label2.Text) && Screenshot.isWindowOpen(label2.Text) == true)
            {
                keyCode = (Keys)comboBox1.SelectedItem;
                Subscribe();
                IsRunningText.Text = "RUNNING";
                IsRunningText.ForeColor = Color.Green;
                //To make sure that the time interval is good.
                positionUpdate.Interval = (Decimal.ToInt32(timeInterval.Value) * 1000);
                modifyChecked = (Modify.CheckState == CheckState.Checked) ? true : false;

                if (Modify.CheckState == CheckState.Unchecked)
                {
                    groupBox3.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Go in game, open f3/Debug screen and press your hotkey.", "IMPORTANT!");
                }
            }
        }

        //When the program is closed, dispose!
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if(savedImageForSetup != null) savedImageForSetup.Dispose();
            if(m_GlobalHook != null) Unsubscribe();
        }

        //The button that switches the coordinate types.
        private void Swich_Coords_Click(object sender, EventArgs e)
        {
            Switch(Swich_Coords);
        }

        //The "function" that draws all the rings on the chart.
        private void chart1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen coolPen = new Pen(Color.FromArgb(25, 255, 0, 0), 1))
            {
                if (chartAreaHeight == 0 || chartAreaWidth == 0) return;
                //update_Axis_Width_Height(ref chart1);
                //short startX = 88, endX = 580;
                //short startY = 26, endY = 460;
                float startX = 95, endX = 601;
                float startY = 59, endY = 457;
                //if (paintIndex != 0) endY -= (3 * (currentMaximum/1000));

                float currentWidth = chart1.ChartAreas[0].Position.Width;
                float currentHeight = chart1.ChartAreas[0].Position.Height;

                if (currentMaximum >= 10000)
                {
                    endX -= 4;
                }

                endX = (endX * (float)(currentWidth / chartAreaWidth));
                endY = (endY * (float)(currentHeight / chartAreaHeight));

                //currentMaximum = 11111;
                //currentMinimum = currentMaximum * -1;
                //create_hori_verti_line(chart1);
                //Console.WriteLine("Width: " + chart1.ChartAreas[0].AxisY.Maximum);
                //e.Graphics.DrawRectangle(blackPen, new Rectangle((int)endX - 50, (int)startY, 80, 250));
                //e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle((int)startX, (int)endY, 80, 25));
                //e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(250, 23, 80, 50));
                //e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(88, 468, 80, 25));

                for (short index = paintIndex; index >= 0; --index)
                {
                    float outerCircleX = (((float)strongHold_radius[index][1] / (float)currentMaximum));
                    float outerCircleXStart = (((endX - startX) / 2) - (((endX - startX) / 2) * outerCircleX)) + startX;
                    float outerCircleXWidth = (endX - startX) - ((outerCircleXStart - startX) * 2);

                    float outerCircleY = (((float)strongHold_radius[index][1] / (float)currentMaximum));
                    float outerCircleYStart = (((endY - startY) / 2) - (((endY - startY) / 2) * outerCircleY)) + startY;
                    float outerCircleYHeight = (endY - startY) - ((outerCircleYStart - startY) * 2);

                    float innerCircleX = (((float)strongHold_radius[index][0] / (float)currentMaximum));
                    float innerCircleXStart = (((endX - startX) / 2) - (((endX - startX) / 2) * innerCircleX)) + startX;
                    float innerCircleXWidth = (endX - startX) - ((innerCircleXStart - startX) * 2);

                    float innerCircleY = (((float)strongHold_radius[index][0] / (float)currentMaximum));
                    float innerCircleYStart = (((endY - startY) / 2) - (((endY - startY) / 2) * innerCircleY)) + startY;
                    float innerCircleYHeight = (endY - startY) - ((innerCircleYStart - startY) * 2);

                    for (short i = 0; ; ++i)
                    {
                        if ((outerCircleXStart + i) >= innerCircleXStart)
                        {
                            break;
                        }
                        e.Graphics.DrawEllipse(coolPen, outerCircleXStart + i, outerCircleYStart + i, outerCircleXWidth - (2 * i), outerCircleYHeight - (2 * i));
                    }
                    //e.ChartGraphics.Graphics.FillEllipse(redBrush, outerCircleXStart, outerCircleYStart, outerCircleXWidth, outerCircleYHeight);
                    //e.ChartGraphics.Graphics.FillEllipse(transparentBrush, innerCircleXStart, innerCircleYStart, innerCircleXWidth, innerCircleYHeight);
                }
            }
        }
    }
}
