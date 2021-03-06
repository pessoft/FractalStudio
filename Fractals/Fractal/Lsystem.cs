﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Fractals.Tools;

namespace Fractals.Fractal
{
    public class Lsystem : Fractal
    {
        struct Source
        {
            public double x1, y1,x2,y2, angle;
        }
        struct Max
        {
            public double x, y;
        }
        struct Min
        {
            public double x, y;
        }
        #region Поля и события класса

        StringBuilder _resultSting;
        string _axiom;
        double _initAngle, _angle;
        double _angleRotation;
        int _iteration;
        double maxX, maxY,cntX,cntY,minX=0,minY=0;
        Dictionary<char, string> _rules;
        Queue<Source> coord;
        Stack<Source> stack;
        PointF[] coordPoints;
        Matrix affinTrn;
        Max max;
        Min min;

        public event EventHandler<CompletedFractalEventArgs> Completed;
        public event EventHandler Starting;
        public event EventHandler<ChangedProgressEventArgs> ChangedProgress;

        #endregion
        public Lsystem(string axiom, Dictionary<char, string> rules, double initAngle, double angle, int iteration = 0)
        {
            _axiom = axiom;
            _rules = rules;
            _initAngle = initAngle;
            _angle = angle;
            _iteration = iteration;
            _angleRotation = _initAngle;
            _resultSting = new StringBuilder(_axiom);
            coord = new Queue<Source>();
            stack = new Stack<Source>();
            _changedProgressEventArgs = new ChangedProgressEventArgs() { Minimum = 0, Maximum = _iteration, Value = 0};
            
            max = new Max();
            min =new Min();
        }

        protected override void Run()
        {
            OnStarting();
            RuleGenerate();
            CoordinateGenerate();
            ImageGenerate();
            OnCompleted();
        }

        #region Генерация конечного правила, координат, изображения
        private void RuleGenerate()
        {
            StringBuilder tmpString;
            for (int i = 0; i < _iteration; ++i)
            {
                
                tmpString = new StringBuilder("");
                for (int j = 0, length = _resultSting.Length; j < length; ++j)
                {
                    switch (_resultSting[j])
                    {
                        case '+':
                        case '-':
                        case '[':
                        case ']': tmpString.Append(_resultSting[j]); break;
                        default:
                            if (_rules.ContainsKey(_resultSting[j]))
                                tmpString.Append(_rules[_resultSting[j]].Trim());
                            break;
                    }
                    
                }
                _resultSting = tmpString;
            }
        }
        private void CoordinateGenerate()
        {
            _changedProgressEventArgs.Maximum = _resultSting.Length+1;
            maxX = _height;
            maxY = _width;
            var coordSource = new Source();
            var coordTmp = new Source();
            var step = _width;
            int oldValue=0;
            coordSource.x1 = 320;
            coordSource.y1 = 320;
            coordSource.x2 = 320;
            coordSource.y2 = 320;
            coordSource.angle = _initAngle;
            _angleRotation = _initAngle;
            //foreach (var chr in _resultSting.ToString())
                for (int i = 0; i < _resultSting.Length; ++i)
                {
                    switch (_resultSting[i])
                    {
                        case '+': _angleRotation += _angle; break;
                        case '-': _angleRotation -= _angle; break;
                        case '[':
                            {
                                Source sourceTmp = coordSource;
                                sourceTmp.angle = _angleRotation;
                                stack.Push(sourceTmp);
                                break;
                            }
                        case ']':
                            {
                                coordSource = stack.Pop();
                                _angleRotation = coordSource.angle;
                                break;
                            }
                        case 'F':
                            {
                                coordTmp = coordSource;
                                coordSource.x1 = coordTmp.x2;
                                coordSource.y1 = coordTmp.y2;
                                coordSource.x2 = coordSource.x1 + step * Math.Sin(Radians(_angleRotation));
                                coordSource.y2 = coordSource.y1 - step * Math.Cos(Radians(_angleRotation));

                                if (coordSource.x1 > maxX)
                                {
                                    maxX = coordSource.x1;
                                    max.x = coordSource.x1;
                                    max.y = coordSource.y1;
                                }
                                if (coordSource.x2 > maxX)
                                {

                                    maxX = coordSource.x2;
                                    max.x = coordSource.x2;
                                    max.y = coordSource.y2;
                                }
                                if (coordSource.y1 > maxY)
                                {
                                    maxY = coordSource.y1;
                                    max.x = coordSource.x1;
                                    max.y = coordSource.y1;
                                }
                                if (coordSource.y2 > maxY)
                                {
                                    maxY = coordSource.y2;
                                    max.x = coordSource.x2;
                                    max.y = coordSource.y2;
                                }

                                if (coordSource.x1 < minX)
                                {
                                    minX = coordSource.x1;
                                    min.x = coordSource.x1;
                                    min.y = coordSource.y1;
                                }
                                if (coordSource.x2 < minX)
                                {
                                    minX = coordSource.x2;
                                    min.x = coordSource.x2;
                                    min.y = coordSource.y2;
                                }

                                if (coordSource.y1 < minY)
                                {
                                    minY = coordSource.y1;
                                    min.x = coordSource.x1;
                                    min.y = coordSource.y1;
                                }
                                if (coordSource.y2 < minY)
                                {
                                    minY = coordSource.y2;
                                    min.x = coordSource.x2;
                                    min.y = coordSource.y2;
                                }

                                coord.Enqueue(coordSource);
                                break;
                            }
                        case 'f':
                            {
                            coordTmp = coordSource;
                            coordSource.x1 = coordTmp.x2;
                            coordSource.y1 = coordTmp.y2;
                            coordSource.x2 = coordSource.x1 + step * Math.Sin(Radians(_angleRotation));
                            coordSource.y2 = coordSource.y1 - step * Math.Cos(Radians(_angleRotation));

                            //if (coordSource.x1 > maxX)
                            //    maxX = coordSource.x1;
                            //if (coordSource.x2 > maxX)
                            //    maxX = coordSource.x2;
                            //if (coordSource.y1 > maxY)
                            //    maxY = coordSource.y1;
                            //if (coordSource.y2 > maxY)
                            //    maxY = coordSource.y2;

                            //if (coordSource.x1 < minX)
                            //    minX = coordSource.x1;
                            //if (coordSource.x2 < minX)
                            //    minX = coordSource.x2;
                            //if (coordSource.y1 < minY)
                            //    minY = coordSource.y1;
                            //if (coordSource.y2 < minY)
                            //    minY = coordSource.y2;

                            break;
                            }
                    }
                    ++_changedProgressEventArgs.Value;
                    if (_changedProgressEventArgs.Value - oldValue == 25)
                    {
                        oldValue = _changedProgressEventArgs.Value;
                        OnChangedProgress();
                    }
                   // OnChangedProgress();
                }

                cntX = coord.Sum(p => p.x1 + p.x2) / (coord.Count * 2);
                cntY = coord.Sum(p => p.y1 + p.y2) / (coord.Count * 2);
                ConvertPoints();
                
              //  Console.Write("end");
        }
        private void ImageGenerate()
        {
            _bmp = new Bitmap(_width, _height);
            Pen pen = new Pen(Brushes.Black);
            using (var g = Graphics.FromImage(_bmp))
            {
                g.Clear(Color.White);
                for (int i = 0; i < coordPoints.Length; i += 2)
                    g.DrawLine(pen,coordPoints[i], coordPoints[i+1]);
            }
        }
        #endregion

        private void ConvertPoints()
        {
            double dx = 0, dy = 0, sx=0, sy=0;
            List<PointF> points = new List<PointF>();
            foreach (var point in coord)
            {
                PointF tmp = new PointF();

                tmp.X = (float)point.x1;
                tmp.Y = (float)point.y1;
                points.Add(tmp);
                tmp = new PointF();
                tmp.X = (float)point.x2;
                tmp.Y = (float)point.y2;
                points.Add(tmp);
            }
            affinTrn = new Matrix(points.ToArray());
            //bool d = false;
            if ((maxX > _width || maxY > _height || minX<0 || minY<0))
            {
                double maxLength1=0,maxLength2=0,maxLength=0,scale=0;
                //if (maxX > _width || maxY>_height)
                //{
                //    if (Math.Sqrt(Math.Pow(max.y - _width / 2, 2)) > Math.Sqrt(Math.Pow(max.x - _width / 2, 2)))
                //    {
                //        maxLength = Math.Sqrt(Math.Pow(max.y - _width / 2, 2));
                //    }
                //    else
                //    {
                //        maxLength = Math.Sqrt(Math.Pow(max.x - _width / 2, 2));
                //    } 
                //}
                //else
                //    if (minX < 0 || minY<0)
                //    {
                //        if (Math.Sqrt(Math.Pow(min.y - _width / 2, 2)) > Math.Sqrt(Math.Pow(min.x - _width / 2, 2)))
                //        {
                //            maxLength = Math.Sqrt(Math.Pow(min.y - _width / 2, 2));
                //        }
                //        else
                //        {
                //            maxLength = Math.Sqrt(Math.Pow(min.x - _width / 2, 2));
                //        }
                //    }

                #region
               

                    maxLength1 = Math.Sqrt(Math.Pow(max.y - _height / 2, 2) + Math.Pow(max.x - _width / 2, 2));
                    maxLength2 = Math.Sqrt(Math.Pow(min.x - _width / 2, 2) + Math.Pow(min.y - _height / 2, 2));

                        if (maxLength1 > maxLength2)
                            maxLength = maxLength1;
                        else
                            maxLength = maxLength2;
                #endregion
                scale = _width/(1.5*maxLength);
                //scale = 0.005;
                affinTrn.Scale(scale, scale, cntX, cntY);
            }
            
            dx = -(cntX - _width / 2);
            dy = -(cntY - _height / 2);
            affinTrn.Transform(dx, dy);
            coordPoints = affinTrn.GetPoints();
        }
        private double Radians(double angle)
        {
            return angle * Math.PI / 180;
        }
        private double Sin(double angle)
        {
            return Math.Sin(angle * Math.PI / 180);
        }
        private double Cos(double angle)
        {
            return Math.Cos(angle * Math.PI / 180);
        }

       
    }
}
