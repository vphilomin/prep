# Pocket Gems - Questions

You have 3 types of gem blocks of sizes 1 × 1 × 1, 1 × 2 × 1, and 2 × 1 × 1

![Key][1]

Assume you have an infinite number of blocks of each type. You want to make a wall of:

*   height K, width 2ⁿ, and depth 1 out of these blocks. 

The wall should not have any holes in it. The blocks cannot be rotated. In how many ways can the wall be built, modulo 1000000007?

![Wall Diagram][2]

Input:  
The first line contains the number of test cases T. T test cases follow. Each test case contains two integers: N and K.

Output:  
Output T lines, one for each test case containing the number of ways to build the wall. As the numbers can be very large, output the result modulo 1000000007.

Constraints:  
1 ≤ T ≤ 100  
0 ≤ N ≤ 1024  
1 ≤ K ≤ 5

Make sure that your program is efficient enough to run the worst case input in a reasonable amount of time on a modern device.

Sample Input:  
5  
1 2  
2 2  
3 4  
4 3  
5 5

Sample Output:  
7  
71  
211351945  
118552334  
634872596

Explanation:  
For the first case, the possible walls are:

![Vertical Blocks][3]

 [1]: Key.png "Key"
 [2]: WallDiagram.png "Wall Diagram"
 [3]: VertBlocks.png "Vertical Blocks"  
