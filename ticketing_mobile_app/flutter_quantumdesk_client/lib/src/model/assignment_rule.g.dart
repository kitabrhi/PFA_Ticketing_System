// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'assignment_rule.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$AssignmentRule extends AssignmentRule {
  @override
  final int? ruleID;
  @override
  final String ruleName;
  @override
  final String? description;
  @override
  final TicketCategory? category;
  @override
  final TicketPriority? priority;
  @override
  final int? assignToTeamID;
  @override
  final String? assignToUserID;
  @override
  final bool isActive;
  @override
  final int ruleOrder;
  @override
  final SupportTeam? assignToTeam;
  @override
  final User? assignToUser;

  factory _$AssignmentRule([void Function(AssignmentRuleBuilder)? updates]) =>
      (new AssignmentRuleBuilder()..update(updates))._build();

  _$AssignmentRule._(
      {this.ruleID,
      required this.ruleName,
      this.description,
      this.category,
      this.priority,
      this.assignToTeamID,
      this.assignToUserID,
      required this.isActive,
      required this.ruleOrder,
      this.assignToTeam,
      this.assignToUser})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(
        ruleName, r'AssignmentRule', 'ruleName');
    BuiltValueNullFieldError.checkNotNull(
        isActive, r'AssignmentRule', 'isActive');
    BuiltValueNullFieldError.checkNotNull(
        ruleOrder, r'AssignmentRule', 'ruleOrder');
  }

  @override
  AssignmentRule rebuild(void Function(AssignmentRuleBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  AssignmentRuleBuilder toBuilder() =>
      new AssignmentRuleBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is AssignmentRule &&
        ruleID == other.ruleID &&
        ruleName == other.ruleName &&
        description == other.description &&
        category == other.category &&
        priority == other.priority &&
        assignToTeamID == other.assignToTeamID &&
        assignToUserID == other.assignToUserID &&
        isActive == other.isActive &&
        ruleOrder == other.ruleOrder &&
        assignToTeam == other.assignToTeam &&
        assignToUser == other.assignToUser;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, ruleID.hashCode);
    _$hash = $jc(_$hash, ruleName.hashCode);
    _$hash = $jc(_$hash, description.hashCode);
    _$hash = $jc(_$hash, category.hashCode);
    _$hash = $jc(_$hash, priority.hashCode);
    _$hash = $jc(_$hash, assignToTeamID.hashCode);
    _$hash = $jc(_$hash, assignToUserID.hashCode);
    _$hash = $jc(_$hash, isActive.hashCode);
    _$hash = $jc(_$hash, ruleOrder.hashCode);
    _$hash = $jc(_$hash, assignToTeam.hashCode);
    _$hash = $jc(_$hash, assignToUser.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'AssignmentRule')
          ..add('ruleID', ruleID)
          ..add('ruleName', ruleName)
          ..add('description', description)
          ..add('category', category)
          ..add('priority', priority)
          ..add('assignToTeamID', assignToTeamID)
          ..add('assignToUserID', assignToUserID)
          ..add('isActive', isActive)
          ..add('ruleOrder', ruleOrder)
          ..add('assignToTeam', assignToTeam)
          ..add('assignToUser', assignToUser))
        .toString();
  }
}

class AssignmentRuleBuilder
    implements Builder<AssignmentRule, AssignmentRuleBuilder> {
  _$AssignmentRule? _$v;

  int? _ruleID;
  int? get ruleID => _$this._ruleID;
  set ruleID(int? ruleID) => _$this._ruleID = ruleID;

  String? _ruleName;
  String? get ruleName => _$this._ruleName;
  set ruleName(String? ruleName) => _$this._ruleName = ruleName;

  String? _description;
  String? get description => _$this._description;
  set description(String? description) => _$this._description = description;

  TicketCategory? _category;
  TicketCategory? get category => _$this._category;
  set category(TicketCategory? category) => _$this._category = category;

  TicketPriority? _priority;
  TicketPriority? get priority => _$this._priority;
  set priority(TicketPriority? priority) => _$this._priority = priority;

  int? _assignToTeamID;
  int? get assignToTeamID => _$this._assignToTeamID;
  set assignToTeamID(int? assignToTeamID) =>
      _$this._assignToTeamID = assignToTeamID;

  String? _assignToUserID;
  String? get assignToUserID => _$this._assignToUserID;
  set assignToUserID(String? assignToUserID) =>
      _$this._assignToUserID = assignToUserID;

  bool? _isActive;
  bool? get isActive => _$this._isActive;
  set isActive(bool? isActive) => _$this._isActive = isActive;

  int? _ruleOrder;
  int? get ruleOrder => _$this._ruleOrder;
  set ruleOrder(int? ruleOrder) => _$this._ruleOrder = ruleOrder;

  SupportTeamBuilder? _assignToTeam;
  SupportTeamBuilder get assignToTeam =>
      _$this._assignToTeam ??= new SupportTeamBuilder();
  set assignToTeam(SupportTeamBuilder? assignToTeam) =>
      _$this._assignToTeam = assignToTeam;

  UserBuilder? _assignToUser;
  UserBuilder get assignToUser => _$this._assignToUser ??= new UserBuilder();
  set assignToUser(UserBuilder? assignToUser) =>
      _$this._assignToUser = assignToUser;

  AssignmentRuleBuilder() {
    AssignmentRule._defaults(this);
  }

  AssignmentRuleBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _ruleID = $v.ruleID;
      _ruleName = $v.ruleName;
      _description = $v.description;
      _category = $v.category;
      _priority = $v.priority;
      _assignToTeamID = $v.assignToTeamID;
      _assignToUserID = $v.assignToUserID;
      _isActive = $v.isActive;
      _ruleOrder = $v.ruleOrder;
      _assignToTeam = $v.assignToTeam?.toBuilder();
      _assignToUser = $v.assignToUser?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(AssignmentRule other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$AssignmentRule;
  }

  @override
  void update(void Function(AssignmentRuleBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  AssignmentRule build() => _build();

  _$AssignmentRule _build() {
    _$AssignmentRule _$result;
    try {
      _$result = _$v ??
          new _$AssignmentRule._(
            ruleID: ruleID,
            ruleName: BuiltValueNullFieldError.checkNotNull(
                ruleName, r'AssignmentRule', 'ruleName'),
            description: description,
            category: category,
            priority: priority,
            assignToTeamID: assignToTeamID,
            assignToUserID: assignToUserID,
            isActive: BuiltValueNullFieldError.checkNotNull(
                isActive, r'AssignmentRule', 'isActive'),
            ruleOrder: BuiltValueNullFieldError.checkNotNull(
                ruleOrder, r'AssignmentRule', 'ruleOrder'),
            assignToTeam: _assignToTeam?.build(),
            assignToUser: _assignToUser?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'assignToTeam';
        _assignToTeam?.build();
        _$failedField = 'assignToUser';
        _assignToUser?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'AssignmentRule', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
