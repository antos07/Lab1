//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\antos07\Documents\University\OOP Labs\Lab1\Lab1\ANTLR4\Expressions.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="ExpressionsParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IExpressionsVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ExpressionsParser.expressionInCell"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionInCell([NotNull] ExpressionsParser.ExpressionInCellContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>cellIdBoolExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.booleanExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellIdBoolExp([NotNull] ExpressionsParser.CellIdBoolExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>orBoolExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.booleanExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrBoolExp([NotNull] ExpressionsParser.OrBoolExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>compBoolExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.booleanExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompBoolExp([NotNull] ExpressionsParser.CompBoolExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>andBoolExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.booleanExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndBoolExp([NotNull] ExpressionsParser.AndBoolExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesisBoolExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.booleanExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesisBoolExp([NotNull] ExpressionsParser.ParenthesisBoolExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>notBoolExpr</c>
	/// labeled alternative in <see cref="ExpressionsParser.booleanExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotBoolExpr([NotNull] ExpressionsParser.NotBoolExprContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multDivArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultDivArExp([NotNull] ExpressionsParser.MultDivArExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plusMinusArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlusMinusArExp([NotNull] ExpressionsParser.PlusMinusArExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>cellIdArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCellIdArExp([NotNull] ExpressionsParser.CellIdArExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionArExp([NotNull] ExpressionsParser.FunctionArExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>unsignedNumericArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnsignedNumericArExp([NotNull] ExpressionsParser.UnsignedNumericArExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenthesisArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesisArExp([NotNull] ExpressionsParser.ParenthesisArExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>signedNumericExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSignedNumericExp([NotNull] ExpressionsParser.SignedNumericExpContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>modArExp</c>
	/// labeled alternative in <see cref="ExpressionsParser.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitModArExp([NotNull] ExpressionsParser.ModArExpContext context);
}
