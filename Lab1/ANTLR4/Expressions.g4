grammar Expressions;

/*
 * Parser Rules
 */

// available operators and functions: +, -, *, /, <, >, =, not(x), max(x, y), min(x, y), and, or, >=, <=, <> 
booleanExpression:
	NOT OPENING_BRACKET booleanExpression CLOSING_BRACKET			# notBoolExpr
	| OPENING_BRACKET booleanExpression CLOSING_BRACKET				# parenthesisBoolExp
	| booleanExpression AND booleanExpression						# andBoolExp
	| booleanExpression OR booleanExpression						# orBoolExp
	| arithmeticExpression COMPARISON_OPERATOR arithmeticExpression	# compBoolExp
	| CELL_ID														# cellIdBoolExp;

arithmeticExpression:
	FUNCTION OPENING_BRACKET arithmeticExpression COMMA arithmeticExpression CLOSING_BRACKET	# functionArExp
	| OPENING_BRACKET arithmeticExpression CLOSING_BRACKET										# parenthesisArExp
	| arithmeticExpression MOD arithmeticExpression												# modArExp
	| arithmeticExpression (MULTIPLY | DIVIDE | DIV) arithmeticExpression						# multDivArExp
	| arithmeticExpression (PLUS | MINUS) arithmeticExpression									# plusMinusArExp
	| OPENING_BRACKET (PLUS | MINUS) UNSIGNED_NUMBER CLOSING_BRACKET							# signedNumericExp
	| UNSIGNED_NUMBER																			# unsignedNumericArExp;

/*
 * Lexer Rules
 */

OPENING_BRACKET: '(';
CLOSING_BRACKET: ')';
COMMA: ',';

fragment EQUAL: '=';
fragment LESS: '<';
fragment LESS_EQUAL: LESS EQUAL;
fragment GREATER: '>';
fragment GREATER_EQUAL: GREATER EQUAL;
fragment NOT_EQUAL: LESS GREATER;
COMPARISON_OPERATOR:
	LESS_EQUAL
	| GREATER_EQUAL
	| NOT_EQUAL
	| EQUAL
	| LESS
	| GREATER;

NOT: 'not';

AND: 'and';
OR: 'or';

PLUS: '+';
MINUS: '-';
MULTIPLY: '*';
DIVIDE: '/';
DIV: 'div';
MOD: 'mod';

FUNCTION: 'max' | 'min';

fragment DIGIT: [0-9];
UNSIGNED_NUMBER: DIGIT+;

fragment UPPERCASE_LETTER: [A-Z];
fragment COLUMN_ID: UPPERCASE_LETTER+;
fragment ROW_ID: UNSIGNED_NUMBER;
CELL_ID: COLUMN_ID ROW_ID;

WHITESPACE: [ \n\t] -> skip;
