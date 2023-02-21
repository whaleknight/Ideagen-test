# Ideagen-test

My implementation on this calculator uses two stacks: stack for operands and operatorStack for operators and parentheses. It scans the input sum from left to right and performs the appropriate operations for each token based on its type (number, operator, or parenthesis).

The GetPrecedence method returns the precedence of an operator, with higher precedence meaning the operator should be evaluated first. The EvaluateTop method pops an operator from operatorStack and two operands from stack, applies the operator to the operands, and pushes the result back onto stack.

This implementation should be able to handle nested parentheses, as well as other features like negative numbers and additional operators or functions with appropriate modifications.
