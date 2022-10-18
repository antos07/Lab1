grammar Expressions;

/*
 * Parser Rules
 */

// available operators and functions: +, -, *, /, <, >, =, not(x), max(x, y), min(x, y), and, or, >=, <=, <> 
boolean_expression:
	NOT? OPENING_BRACKET boolean_expression CLOSING_BRACKET
	| boolean_expression boolean_operator boolean_expression
	| arithmetic_expression comparison_operator arithmetic_expression
	| cell_id;

comparison_operator:
	EQUAL
	| LESS
	| LESS_EQUAL
	| GREATER
	| GREATER_EQUAL
	| NOT_EQUAL;

boolean_operator: OR | AND;

arithmetic_expression:
	OPENING_BRACKET arithmetic_expression CLOSING_BRACKET
	| arithmetic_expression arithmetic_operator arithmetic_expression
	| function OPENING_BRACKET arithmetic_expression COMMA arithmetic_expression CLOSING_BRACKET
	| SIGNED_NUMBER;

arithmetic_operator:
	PLUS
	| MINUS
	| MULTIPLY
	| DIVIDE
	| MOD
	| DIV;

function: MAX | MIN;

cell_id: UPPERCASE_LETTER+ UNSIGNED_NUMBER;

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
