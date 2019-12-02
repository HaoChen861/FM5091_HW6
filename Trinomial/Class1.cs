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
        double dt;//time change in a step

        double [,] p_mat;//price matrix
        double [,] c_mat;//option matrix

        double[,] p_mat_vega_u;
        double[,] p_mat_vega_d;

        double[,] c_mat_rho_u;
        double[,] c_mat_rho_d;
        double[,] c_mat_vega_u;
        double[,] c_mat_vega_d;


        //greeks:
        double delta;
        double gamma;
        double theta;
        double vega;
        double rho;

        



        public Trinomial(double aK, double aS ,double aR , double aT, double aSig, double aDiv,int aN)
        {
            k = aK;
            s = aS;
            r = aR;
            t = aT;
            sig = aSig;
            div = aDiv;
            n = aN+1;
            dt = t / (n - 1);

            p_mat =p_mat_fun(s,t,sig,n);
            p_mat_vega_u = p_mat_fun(s, t, sig+0.001, n);
            p_mat_vega_d = p_mat_fun(s, t, sig-0.001, n);

            c_mat = c_mat_fun_setup(p_mat);
            c_mat_vega_u = c_mat_fun_setup(p_mat_vega_u);
            c_mat_vega_d = c_mat_fun_setup(p_mat_vega_d);


        }


        /// <summary>
        /// Populate the S matrix. the highest row have 1/edx for each subsequent value. and then times each value by edx based on the previous row value. 
        /// </summary>
        /// <returns>the S matrix</returns>
        private double[,] p_mat_fun(double s, double t, double sig,int n)
        {
            double dx;
            double edx; //e^dx



            dx = sig * Math.Sqrt(3 * dt);
            edx = Math.Pow(Math.E, dx);


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
        public double[,] c_mat_fun_setup(double [,] mat2)
        {
            double[,] mat = new double[2 * n - 1, n];

            for (int i = 0; i < 2 * n - 1; i++)
            {
                mat[i, n-1] = mat2[i, n-1];
            }


            return mat;
        }
        /// <summary>
        /// American mat, have 
        /// </summary>
        /// <returns></returns>
        public double[,] c_mat_fun(double k,double r,double t, double sig, double div, int n,string type,double [,] c_mat,double [,] p_mat)
        {
            double v;
            double pu;//p of going up
            double pm;//p of stay the same
            double pd;//p of going down
            double disc;//discount
            double dx;



            dx = sig * Math.Sqrt(3 * dt);



            v = r - div - (0.5) * Math.Pow(sig, 2);

            //pu=1/2*((sig^2dt+v^2dt^2)/(dx^2)+(vdt)/(dx))
            pu = (0.5) * ((Math.Pow(sig, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / (Math.Pow(dx, 2)) + (v * dt) / (dx));

            //pm=1-((sig^2dt+v^2dt^2)/(dx^2))
            pm = 1 - ((Math.Pow(sig, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / (Math.Pow(dx, 2)));

            //pd=1/2*((sig^2dt+v^2dt^2)/(dx^2)-(vdt)/(dx))
            pd = (0.5) * ((Math.Pow(sig, 2) * dt + Math.Pow(v, 2) * Math.Pow(dt, 2)) / (Math.Pow(dx, 2)) - (v * dt) / (dx));

            disc = Math.Pow(Math.E, -r * dt);


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
                        if (type == "AC")//AC is amer call
                        {
                            c_mat[i, j] = Math.Max(disc * (pd * c_mat[i, j + 1] + pm * c_mat[i + 1, j + 1] + pu * c_mat[i + 2, j + 1]), p_mat[i, j] - k);
                        }
                        else if( type == "AP")//AP is amer put
                        {
                            c_mat[i, j] = Math.Max(disc * (pd * c_mat[i, j + 1] + pm * c_mat[i + 1, j + 1] + pu * c_mat[i + 2, j + 1]), k - p_mat[i, j]);
                        }
                        else
                        {
                            c_mat[i, j] = disc * (pd * c_mat[i, j + 1] + pm * c_mat[i + 1, j + 1] + pu * c_mat[i + 2, j + 1]);
                        }
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
                //base c_mat
                for (int h=0; h < 2 * n - 1; h++)
                {
                    c_mat[h, n - 1] = Math.Max(0, c_mat[h, n - 1] - k);
                }

                double[,] c_mat_2 = deep_copy_mat(c_mat);
                double[,] c_mat_3 = deep_copy_mat(c_mat);

                c_mat = c_mat_fun(k, r,t, sig, div, n,"AC",c_mat,p_mat);

                //vega c_mat
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_u[h, n - 1] = Math.Max(0, c_mat_vega_u[h, n - 1] - k);
                }

                c_mat_vega_u = c_mat_fun(k, r,t, sig+0.001, div, n, "AC",c_mat_vega_u,p_mat_vega_u);

                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_d[h, n - 1] = Math.Max(0, c_mat_vega_d[h, n - 1] - k);
                }

                c_mat_vega_d = c_mat_fun(k, r,t, sig - 0.001, div, n, "AC",c_mat_vega_d,p_mat_vega_d);

                //rho c_mat

                c_mat_rho_u = c_mat_fun(k, r+0.001,t, sig, div, n, "AC",c_mat_2,p_mat);
                c_mat_rho_d = c_mat_fun(k, r-0.001,t, sig, div, n, "AC",c_mat_3,p_mat);

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

                double[,] c_mat_2 = deep_copy_mat(c_mat);
                double[,] c_mat_3 = deep_copy_mat(c_mat);

                c_mat = c_mat_fun(k, r,t, sig, div, n, "AP",c_mat,p_mat);
                
                //vega c_mat
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_u[h, n - 1] = Math.Max(0, k - c_mat_vega_u[h, n - 1]);
                }

                c_mat_vega_u = c_mat_fun(k, r,t, sig + 0.001, div, n, "AP",c_mat_vega_u,p_mat_vega_u);

                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_d[h, n - 1] = Math.Max(0, k - c_mat_vega_d[h, n - 1]);
                }

                c_mat_vega_d = c_mat_fun(k, r,t, sig - 0.001, div, n, "AP",c_mat_vega_d,p_mat_vega_d);

                //rho c_mat

                c_mat_rho_u = c_mat_fun(k, r + 0.001,t, sig, div, n, "AP",c_mat_2,p_mat);
                c_mat_rho_d = c_mat_fun(k, r - 0.001,t, sig, div, n, "AP",c_mat_3,p_mat);



            }
        }

        public class euro_call : Trinomial
        {
            public euro_call(double aK, double aS, double aR, double aT, double aSig, double aDiv, int aN)
                : base(aK, aS, aR, aT, aSig, aDiv, aN)
            {
                //base case
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat[h, n - 1] = Math.Max(0, c_mat[h, n - 1] - k);
                }
                double[,] c_mat_2 = deep_copy_mat(c_mat);
                double[,] c_mat_3 = deep_copy_mat(c_mat);

                c_mat = c_mat_fun(k, r,t, sig, div, n, "E",c_mat,p_mat);

                //vega c_mat
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_u[h, n - 1] = Math.Max(0, c_mat_vega_u[h, n - 1] - k);
                }

                c_mat_vega_u = c_mat_fun(k, r,t, sig + 0.001, div, n, "E",c_mat_vega_u,p_mat_vega_u);

                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_d[h, n - 1] = Math.Max(0, c_mat_vega_d[h, n - 1] - k);
                }

                c_mat_vega_d = c_mat_fun(k, r,t, sig - 0.001, div, n, "E",c_mat_vega_d,p_mat_vega_d);

                //rho c_mat

                c_mat_rho_u = c_mat_fun(k, r + 0.001,t, sig, div, n, "E",c_mat_2,p_mat);
                c_mat_rho_d = c_mat_fun(k, r - 0.001,t, sig, div, n, "E",c_mat_3,p_mat);



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
                double[,] c_mat_2 = deep_copy_mat(c_mat);
                double[,] c_mat_3 = deep_copy_mat(c_mat);

                c_mat = c_mat_fun(k, r,t, sig, div, n, "E",c_mat,p_mat);

                //vega c_mat
                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_u[h, n - 1] = Math.Max(0, k - c_mat_vega_u[h, n - 1]);
                }

                c_mat_vega_u = c_mat_fun(k, r,t, sig + 0.001, div, n, "E",c_mat_vega_u,p_mat_vega_u);

                for (int h = 0; h < 2 * n - 1; h++)
                {
                    c_mat_vega_d[h, n - 1] = Math.Max(0, k - c_mat_vega_d[h, n - 1]);
                }

                c_mat_vega_d = c_mat_fun(k, r,t, sig - 0.001, div, n, "E",c_mat_vega_d,p_mat_vega_d);

                //rho c_mat

                c_mat_rho_u = c_mat_fun(k, r + 0.001,t, sig, div, n, "E",c_mat_2,p_mat);
                c_mat_rho_d = c_mat_fun(k, r - 0.001,t, sig, div, n, "E",c_mat_3,p_mat);



            }
        }



        public virtual double get_price()
        {
            return c_mat[0, 0];
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

        public double get_vega()
        {
            vega = (c_mat_vega_u[0, 0] - c_mat_vega_d[0, 0]) / 0.002;
            return vega;
        }

        public double get_rho()
        {
            rho = (c_mat_rho_u[0, 0] - c_mat_rho_d[0, 0]) / 0.002;
            return rho;
        }

        public double[,] deep_copy_mat(double [,] mat)
        {
            double[,] mat_copy = mat.Clone() as double[,];

            return mat_copy;
        }

    }



}
