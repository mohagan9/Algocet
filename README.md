![alt text](https://github.com/mohagan9/Algocet/blob/master/algocet-logo.png?raw=true)

The goal of Algocet is to solve coding challenges. 
<br>It will do this by converting a declarative problem description into imperative C# code.  

This is a .NET Core 2.1 application using syntax trees and the Roslyn compiler. 

<h2>Overview</h2>

There are three main sub-projects:

 - <b>Algocet:</b> Generates a solution in the form of a CSharpSyntaxTree for a given problem.
 - <b>AlgocetConsole:</b> A CLI that takes a problem statement and saves the C# solution to a text file.
 - <b>CodingChallenges:</b> A test project to verify that Algocet is producing the correct solutions.
 
 Each problem statement is composed of <b>functions</b> and optional <b>constraints</b>.
 
 <h2>Functions</h2>
 
 <table>
 <tbody>
 <tr><td><b>Name</b></td><td><b>Description</b></td><td><b>Input</b></td><td><b>Output</b></td><td><b>Constraints</b></td><td><b>Requirement</b></td></tr>
 <tr><td>MAX</td><td>Returns the maximum element</td><td>int[]</td><td>int</td><td>Positive, Negative</td><td>-</td></tr>
 <tr><td>MIN</td><td>Returns the minimum element</td><td>int[]</td><td>int</td><td>Positive, Negative</td><td>-</td></tr>
 <tr><td>SUM</td><td>Returns the sum of the elements</td><td>int[]</td><td>int</td><td>Positive, Negative</td><td>-</td></tr>
 <tr><td>UNPAIRED</td><td>Returns the element that has no matching pair</td><td>int[]</td><td>int</td><td>Positive, Negative</td><td>There must be exactly one unpaired element in the array</td></tr>
 <tr><td>COMPLEMENT</td><td>Returns an array with the values not present in the input</td><td>int[]</td><td>int[]</td><td>Positive</td><td>Elements are in the range of -1,000,000 to 1,000,000</td></tr>
 </tbody>
 </table>

 

 
 
 
 
 
 
