grammar Expressions;

/*
 * Parser Rules
 */

// available operators and functions: +, -, *, /, <, >, =, not(x), max(x, y), min(x, y), and, or, >=, <=, <> 
booleanExpression:
	NOT? OPENING_BRACKET booleanExpression CLOSING_BRACKET
	| booleanExpression booleanOperator booleanExpression
	| arithmeticExpression comparisonOperator arithmeticExpression
	| cellId;

comparisonOperator:
	EQUAL
	| LESS
	| LESS_EQUAL
	| GREATER
	| GREATER_EQUAL
	| NOT_EQUAL;

booleanOperator: OR | AND;

arithmeticExpression:
	OPENING_BRACKET arithmeticExpression CLOSING_BRACKET
	| arithmeticExpression arithmeticOperator arithmeticExpression
	| function OPENING_BRACKET arithmeticExpression COMMA arithmeticExpression CLOSING_BRACKET
	| SIGNED_NUMBER;

arithmeticOperator:
	PLUS
	| MINUS
	| MULTIPLY
	| DIVIDE
	| MOD
	| DIV;

function: MAX | MIN;

cellId: UPPERCASE_LETTER+ UNSIGNED_NUMBER;

/*
 * Lexer Rules
*/

OPENING_BRACKET: '(';
CLOSING_BRACKET: ')';
COMMA: ',';

EQUAL: '=';
LESS: '<';
LESS_EQUAL: LESS EQUAL;
GREATER: '>';
GREATER_EQUAL: GREATER EQUAL;
NOT_EQUAL: LESS GREATER;

NOT: 'not';

AND: 'and';
OR: 'or';

UPPERCASE_LETTER: [A-Z];

PLUS: '+';
MINUS: '-';
MULTIPLY: '*';
DIVIDE: '/';
DIV: 'div';
MOD: 'mod';

MAX: 'max';
MIN: 'min';

DIGIT: [0-9];
UNSIGNED_NUMBER: DIGIT+;
SIGNED_NUMBER: (PLUS | MINUS)? UNSIGNED_NUMBER;


WHITESPACE: ' ' | '\n' | '\t' -> skip;
