// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'escalation_rule.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$EscalationRule extends EscalationRule {
  @override
  final int? ruleID;
  @override
  final String ruleName;
  @override
  final String? description;
  @override
  final TicketPriority? priority;
  @override
  final TicketStatus? status;
  @override
  final int escalateAfterHours;
  @override
  final String? escalateToUserID;
  @override
  final int? escalateToTeamID;
  @override
  final String? notifyUserIDs;
  @override
  final bool isActive;
  @override
  final User? escalateToUser;
  @override
  final SupportTeam? escalateToTeam;

  factory _$EscalationRule([void Function(EscalationRuleBuilder)? updates]) =>
      (new EscalationRuleBuilder()..update(updates))._build();

  _$EscalationRule._(
      {this.ruleID,
      required this.ruleName,
      this.description,
      this.priority,
      this.status,
      required this.escalateAfterHours,
      this.escalateToUserID,
      this.escalateToTeamID,
      this.notifyUserIDs,
      required this.isActive,
      this.escalateToUser,
      this.escalateToTeam})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(
        ruleName, r'EscalationRule', 'ruleName');
    BuiltValueNullFieldError.checkNotNull(
        escalateAfterHours, r'EscalationRule', 'escalateAfterHours');
    BuiltValueNullFieldError.checkNotNull(
        isActive, r'EscalationRule', 'isActive');
  }

  @override
  EscalationRule rebuild(void Function(EscalationRuleBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  EscalationRuleBuilder toBuilder() =>
      new EscalationRuleBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is EscalationRule &&
        ruleID == other.ruleID &&
        ruleName == other.ruleName &&
        description == other.description &&
        priority == other.priority &&
        status == other.status &&
        escalateAfterHours == other.escalateAfterHours &&
        escalateToUserID == other.escalateToUserID &&
        escalateToTeamID == other.escalateToTeamID &&
        notifyUserIDs == other.notifyUserIDs &&
        isActive == other.isActive &&
        escalateToUser == other.escalateToUser &&
        escalateToTeam == other.escalateToTeam;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, ruleID.hashCode);
    _$hash = $jc(_$hash, ruleName.hashCode);
    _$hash = $jc(_$hash, description.hashCode);
    _$hash = $jc(_$hash, priority.hashCode);
    _$hash = $jc(_$hash, status.hashCode);
    _$hash = $jc(_$hash, escalateAfterHours.hashCode);
    _$hash = $jc(_$hash, escalateToUserID.hashCode);
    _$hash = $jc(_$hash, escalateToTeamID.hashCode);
    _$hash = $jc(_$hash, notifyUserIDs.hashCode);
    _$hash = $jc(_$hash, isActive.hashCode);
    _$hash = $jc(_$hash, escalateToUser.hashCode);
    _$hash = $jc(_$hash, escalateToTeam.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'EscalationRule')
          ..add('ruleID', ruleID)
          ..add('ruleName', ruleName)
          ..add('description', description)
          ..add('priority', priority)
          ..add('status', status)
          ..add('escalateAfterHours', escalateAfterHours)
          ..add('escalateToUserID', escalateToUserID)
          ..add('escalateToTeamID', escalateToTeamID)
          ..add('notifyUserIDs', notifyUserIDs)
          ..add('isActive', isActive)
          ..add('escalateToUser', escalateToUser)
          ..add('escalateToTeam', escalateToTeam))
        .toString();
  }
}

class EscalationRuleBuilder
    implements Builder<EscalationRule, EscalationRuleBuilder> {
  _$EscalationRule? _$v;

  int? _ruleID;
  int? get ruleID => _$this._ruleID;
  set ruleID(int? ruleID) => _$this._ruleID = ruleID;

  String? _ruleName;
  String? get ruleName => _$this._ruleName;
  set ruleName(String? ruleName) => _$this._ruleName = ruleName;

  String? _description;
  String? get description => _$this._description;
  set description(String? description) => _$this._description = description;

  TicketPriority? _priority;
  TicketPriority? get priority => _$this._priority;
  set priority(TicketPriority? priority) => _$this._priority = priority;

  TicketStatus? _status;
  TicketStatus? get status => _$this._status;
  set status(TicketStatus? status) => _$this._status = status;

  int? _escalateAfterHours;
  int? get escalateAfterHours => _$this._escalateAfterHours;
  set escalateAfterHours(int? escalateAfterHours) =>
      _$this._escalateAfterHours = escalateAfterHours;

  String? _escalateToUserID;
  String? get escalateToUserID => _$this._escalateToUserID;
  set escalateToUserID(String? escalateToUserID) =>
      _$this._escalateToUserID = escalateToUserID;

  int? _escalateToTeamID;
  int? get escalateToTeamID => _$this._escalateToTeamID;
  set escalateToTeamID(int? escalateToTeamID) =>
      _$this._escalateToTeamID = escalateToTeamID;

  String? _notifyUserIDs;
  String? get notifyUserIDs => _$this._notifyUserIDs;
  set notifyUserIDs(String? notifyUserIDs) =>
      _$this._notifyUserIDs = notifyUserIDs;

  bool? _isActive;
  bool? get isActive => _$this._isActive;
  set isActive(bool? isActive) => _$this._isActive = isActive;

  UserBuilder? _escalateToUser;
  UserBuilder get escalateToUser =>
      _$this._escalateToUser ??= new UserBuilder();
  set escalateToUser(UserBuilder? escalateToUser) =>
      _$this._escalateToUser = escalateToUser;

  SupportTeamBuilder? _escalateToTeam;
  SupportTeamBuilder get escalateToTeam =>
      _$this._escalateToTeam ??= new SupportTeamBuilder();
  set escalateToTeam(SupportTeamBuilder? escalateToTeam) =>
      _$this._escalateToTeam = escalateToTeam;

  EscalationRuleBuilder() {
    EscalationRule._defaults(this);
  }

  EscalationRuleBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _ruleID = $v.ruleID;
      _ruleName = $v.ruleName;
      _description = $v.description;
      _priority = $v.priority;
      _status = $v.status;
      _escalateAfterHours = $v.escalateAfterHours;
      _escalateToUserID = $v.escalateToUserID;
      _escalateToTeamID = $v.escalateToTeamID;
      _notifyUserIDs = $v.notifyUserIDs;
      _isActive = $v.isActive;
      _escalateToUser = $v.escalateToUser?.toBuilder();
      _escalateToTeam = $v.escalateToTeam?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(EscalationRule other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$EscalationRule;
  }

  @override
  void update(void Function(EscalationRuleBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  EscalationRule build() => _build();

  _$EscalationRule _build() {
    _$EscalationRule _$result;
    try {
      _$result = _$v ??
          new _$EscalationRule._(
            ruleID: ruleID,
            ruleName: BuiltValueNullFieldError.checkNotNull(
                ruleName, r'EscalationRule', 'ruleName'),
            description: description,
            priority: priority,
            status: status,
            escalateAfterHours: BuiltValueNullFieldError.checkNotNull(
                escalateAfterHours, r'EscalationRule', 'escalateAfterHours'),
            escalateToUserID: escalateToUserID,
            escalateToTeamID: escalateToTeamID,
            notifyUserIDs: notifyUserIDs,
            isActive: BuiltValueNullFieldError.checkNotNull(
                isActive, r'EscalationRule', 'isActive'),
            escalateToUser: _escalateToUser?.build(),
            escalateToTeam: _escalateToTeam?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'escalateToUser';
        _escalateToUser?.build();
        _$failedField = 'escalateToTeam';
        _escalateToTeam?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'EscalationRule', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
