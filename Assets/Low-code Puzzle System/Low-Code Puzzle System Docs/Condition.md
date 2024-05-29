A basic unit that represents a true or false (boolean) state, with events that fire on state changes.
- **IsMet:** is a boolean (true or false) value that represents whether the condition is presently satisfied.
- **OnBecomesTrue:** is invoked when the condition is updated to be true and it was previously false.
- **OnStaysTrue:** is invoked when the condition is updated to be true but it was already true.
- **OnBecomesFalse:** is invoked when the condition is updated to be false and it was previously false
- **OnStaysFalse:** is invoked when the condition is updated to be false but it was already false.
- **OnUpdate:** is invoked when the condition is updated.
