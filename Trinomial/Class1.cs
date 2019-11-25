using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinomial
{
    class Trinomial
    {
        double k;//strike
        double s;//underlying
        double r;//interest
        double t;//term
        double sig;//vol
        double div;//dividend
        int n;//number of step
        double dx;
        double edx; //e^dx
        double dt;//time change in a step
        double v;
        double pu;//p of going up
        double pm;//p of stay the same
        double pd;//p of going down
        double disc;//discount
        double [,] p_mat;//price matrix
        double [,] c_mat;//option matrix

        //greeks:
        double delta;
        double gamma;
        double theta;


        



        public Trinomial(double aK, double aS ,double aR , double aT, double aSig, double aDiv,int aN)
        {
            k = aK;
            s = aS;
            r = aR;
            t = aT;
            sig = aSig;
            div = aDiv;
            n = aN+1;
            
            dt = t / (n-1);
            dx = sig * Math.Sqrt(3 * dt);
            edx = Math.Pow(Math.E,dx);

            v = r-div -(0.5)*Math.Pow(sig,2);

            //pu=1/2*((sig^2dt+v^2dt^2)/(dx^2)+(vdt)/(dx))
            pu = (0.5) * ((Math.Pow(sig, 2) * dt+Math.Pow(v,2)*Math.Pow(dt,2)) / (Math.Pow(dx, 2)) + (v * dt) / (dx));

            //pm=1-((sig^2dt+v^2dt^2)/(dx^2))
            pm = 1 - ((Math.Pow(sig, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / (Math.Pow(dx, 2)));

            //pd=1/2*((sig^2dt+v^2dt^2)/(dx^2)-(vdt)/(dx))
            pd = (0.5) * ((Math.Pow(sig, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / (Math.Pow(dx, 2)) - (v * dt) / (dx));

            disc = Math.Pow( Math.E, -r * dt);

            p_mat =p_mat_fun();
            c_mat = c_mat_fun_setup();
            

            
        }


        public virtual double get_price()
        {
            return c_mat[0,0];
        }

        /// <summary>
        /// Populate the S matrix. the highest row have 1/edx for each subsequent value. and then times each value by edx based on the previous row value. 
        /// </summary>
        /// <returns>the S matrix</returns>
        private double[,] p_mat_fun()
        {
            double[,] mat = new double[2 * n -1, n];
            mat[0, 0] = s;
            for (int h =1; h < n; h++)
            {
                mat[0, h] = mat[0, 0] / Math.Pow(edx, h);
            }
            for (int i = 1; i < 2*n-1; i++)
            {
                for (int j = 1; j < n ; j++)
                {
                    if (j<i/2)
                    {
                        mat[i, j] = 0;
                    }
                    else
                    {
                        mat[i, j] = mat[i-1,j]*edx;
                    }
                }
            }

            return mat;    
        }

        /// <summary>
        /// setup value for the c_mat, add values of the last column of p to c_mat
        /// </summary>
        /// <returns>c mat</returns>
        public double[,] c_mat_fun_setup()
        {
            double[,] mat = new double[2 * n - 1, n];

            for (int i = 0; i < 2 * n - 1; i++)
            {
                mat[i, n-1] = p_mat[i, n-1];
            }


            return mat;
        }
        /// <summary>
        /// American mat, have 
        /// </summary>
        /// <returns></returns>
        public double[,] c_mat_fun_a_call()
        {
            for (int j = n-2; j >= 0; j--)
            {
                for (int i = 2*(n-2); i >=0; i --)
                {
                    if (j < i / 2)
                    {
                        c_mat[i, j] = 0;
                    }
                    else
                    {
                        c_mat[i, j] = Math.Max( disc * (pd * c_mat[i, j + 1] + pm * c_mat[i + 1, j + 1] + pu * c_mat[i + 2, j + 1]),p_mat[i,j]-k);
                    }
                }
            }

            return c_mat;
        }

        /// <summary>
        /// American put function, max of (k-p_mat[i,j],c_mat[i,j])
        /// </summary>
        /// <returns></returns>
        public double[,] c_mat_fun_a_put()
        {
            for (int j = n - 2; j >= 0; j--)
            {
                for (int i = 2 * (n - 2); i >= 0; i--)
                {
                    if (j < i / 2)
                    {
                        c_mat[i, j] = 0;
                    }
                    else
                    {
                        c_mat[i, j] = Math.Max(disc * (pd * c_mat[i, j + 1] + pm * c_mat[i + 1, j + 1] + pu * c_mat[i + 2, j + 1]), k-p_mat[i, j]);
                    }
                }
            }

            return c_mat;
        }

        /// <summary>
        /// Function to build c_mat 
        /// </summary>
        /// <returns></returns>
        public double[,] c_mat_fun_c()
        {
            for (int j = n - 2; j >= 0; j--)
            {
                for (int i = 2 * (n - 2); i >= 0; i--)
                {
                    if (j < i / 2)
                    {
                        c_mat[i, j] = 0;
                    }
                    else
                    {
                        c_mat[i, j] = disc * (pd * c_mat[i, j + 1] + pm * c_mat[i + 1, j + 1] + pu * c_mat[i + 2, j + 1]);
                    }
                }
            }

            return c_mat;
        }


        /// <summary>
        /// call and put uses different functions to generate initial value and its option matrix, 
        /// </summary>
        public class amer_call:Trinomial
        {
            public amer_call(double aK, double aS, double aR, double aT, double aSig, double aDiv, int aN)
                :base(aK,aS,aR,aT,aSig,aDiv,aN)
            {
                for (int h=0; h < 2 * n - 1; h++)
                {
                    c_mat[h, n - 1] = Math.Max(0, c_mat[h, n - 1] - k);
                }

                c_mat = c_mat_fun_a_call();



            }
        }

        public class amer_put : Trinomial
        {
            public amer_put(double aK, double aS, double aR, double aT, double aSig, double aDiv, int aN)
                : base(aK, aS, aR, aT, aSig, aDiv, aN)
            {
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat[h, n - 1] = Math.Max(0,k- c_mat[h, n - 1]);
                }

                c_mat = c_mat_fun_a_put();



            }
        }

        public class euro_call : Trinomial
        {
            public euro_call(double aK, double aS, double aR, double aT, double aSig, double aDiv, int aN)
                : base(aK, aS, aR, aT, aSig, aDiv, aN)
            {
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat[h, n - 1] = Math.Max(0, c_mat[h, n - 1] - k);
                }

                c_mat = c_mat_fun_c();



            }
        }

        public class euro_put : Trinomial
        {
            public euro_put(double aK, double aS, double aR, double aT, double aSig, double aDiv, int aN)
                : base(aK, aS, aR, aT, aSig, aDiv, aN)
            {
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat[h, n - 1] = Math.Max(0, k - c_mat[h, n - 1]);
                }

                c_mat = c_mat_fun_c();



            }
        }


        public double get_delta()
        {
            delta = (c_mat[2, 1] - c_mat[0, 1]) / (p_mat[2,1]-p_mat[0,1]);

            return delta;
        }

        public double get_gamma()
        {
            gamma = ((c_mat[2, 1] - c_mat[1, 1]) / (p_mat[2, 1] - p_mat[1, 1]) - (c_mat[1, 1] - c_mat[0, 1]) / (p_mat[1, 1] - p_mat[0, 1])) / (0.5 * (p_mat[2, 1] - p_mat[0, 1]));

            return gamma;
        }

        public double get_theta()
        {
            theta = (c_mat[1, 1] - c_mat[0, 0]) / dt;
            return theta;
        }

    }



}
