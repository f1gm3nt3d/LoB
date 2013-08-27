using System;

namespace New_Dawn.Game
{
 //
 // An implementation of the Mersenne Twister algorithm (MT19937), developed
 // with reference to the C code written by Takuji Nishimura and Makoto Matsumoto
 // (http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html).
 //
 // This code is free to use for any pupose.
 //


 ///
 /// A random number generator with a uniform distribution using the Mersenne
 /// Twister algorithm.
 ///

 public class NumGen
 {
     private const int N = 624;
     private const int M = 397;
     private const uint MATRIX_A = 2567483615u;
     private const uint UPPER_MASK = 2147483648u;
     private const uint LOWER_MASK = 2147483647u;
    
     private readonly uint[] mt = new uint[N];
     private int mti = N + 1;
    
     /// <summary>
     /// Create a new Mersenne Twister random number generator.
     /// </summary>
     public NumGen() : this((uint)DateTime.Now.Millisecond)
     {
     }
    
     /// <summary>
     /// Create a new Mersenne Twister random number generator with a
     /// particular seed.
     /// </summary>
     /// <param name="seed">The seed for the generator.</param>
    
     public NumGen(uint seed)
     {
         mt[0] = seed;
         for (mti = 1; mti <= N - 1; mti++) {
             mt[mti] = (uint)((1812433253ul * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + (uint)mti) & 4294967295ul);
         }
     }
    
     /// <summary>
     /// Create a new Mersenne Twister random number generator with a
     /// particular initial key.
     /// </summary>
     /// <param name="initialKey">The initial key.</param>
     
     public NumGen(uint[] initialKey) : this(19650218u)
     {
         var i = 1;
         var j = 0;
         var k = (N > initialKey.Length ? N : initialKey.Length);
        
         for (k=k ; k >= 1; k += -1) {
             mt[i] = (uint)((mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525ul)) + initialKey[j] + (uint)j) & 4294967295u;
             i += 1;
             j += 1;
             if (i >= N)
                 mt[0] = mt[N - 1];

                 i = 1;
             if (j >= initialKey.Length)
                 j = 0;
         }
        
         for (k = N - 1; k >= 1; k += -1) {
             mt[i] = (uint)((mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941ul)) - (uint)i) & 4294967295u;
             i += 1;
             if (i >= N)
                 mt[0] = mt[N - 1];

                 i = 1;
         }
        
         mt[0] = 2147483648u;
     }
    
     /// <summary>
     /// Generates a random number between 0 and System.UInt32.MaxValue.
     /// </summary>
     public uint NextUInt32()
     {
         uint y;
        
         if (mti >= N) {
             int kk;
            
             //System.Debug.Assert(mti != N + 1, "Failed initialization");
            
             for (kk = 0; kk <= N - M - 1; kk++) {
                 y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                 mt[kk] = mt[kk + M] ^ (y >> 1) ^ static_NextUInt32_mag01[(int)y & 1];
             }
            
             for (kk=kk; kk <= N - 2; kk++) {
                 y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                 mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ static_NextUInt32_mag01[(int)y & 1];
             }
            
             y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
             mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ static_NextUInt32_mag01[(int)y & 1];
            
             mti = 0;
         }
        
         y = mt[mti];
         mti += 1;
        
         // Tempering
         y = y ^ (y >> 11);
         y = y ^ ((y << 7) & 2636928640u);
         y = y ^ ((y << 15) & 4022730752u);
         y = y ^ (y >> 18);
        
         return y;
     }
     static readonly uint[] static_NextUInt32_mag01 = {0u, MATRIX_A};
    
     /// <summary>
     /// Generates a random integer between 0 and System.Int32.MaxValue.
     /// </summary>
     public int Next()
     {
         return (int)NextUInt32() >> 1;
     }
    
     /// <summary>
     /// Generates a random integer between 0 and maxValue.
     /// </summary>
     /// <param name="maxValue">The maximum value. Must be greater than zero.</param>
     public int Next(int maxValue)
     {
         return Next(0, maxValue);
     }
    
     /// <summary>
     /// Generates a random integer between minValue and maxValue.
     /// </summary>
     /// <param name="maxValue">The lower bound.</param>
     /// <param name="minValue">The upper bound.</param>
     public int Next(int minValue, int maxValue)
     {
         return (int)Math.Floor((maxValue - minValue + 1) * NextDouble() + minValue);
     }
    
     /// <summary>
     /// Generates a random floating point number between 0 and 1.
     /// </summary>
     public double NextDouble()
     {
         return NextUInt32() * (1.0 / 4294967295.0);
     }
 }
}
