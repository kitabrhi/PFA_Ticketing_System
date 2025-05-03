// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'support_team.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$SupportTeam extends SupportTeam {
  @override
  final int? teamID;
  @override
  final String teamName;
  @override
  final String? description;
  @override
  final String? managerId;
  @override
  final User? manager;
  @override
  final BuiltList<TeamMember>? teamMembers;
  @override
  final BuiltList<Ticket>? assignedTickets;

  factory _$SupportTeam([void Function(SupportTeamBuilder)? updates]) =>
      (new SupportTeamBuilder()..update(updates))._build();

  _$SupportTeam._(
      {this.teamID,
      required this.teamName,
      this.description,
      this.managerId,
      this.manager,
      this.teamMembers,
      this.assignedTickets})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(teamName, r'SupportTeam', 'teamName');
  }

  @override
  SupportTeam rebuild(void Function(SupportTeamBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  SupportTeamBuilder toBuilder() => new SupportTeamBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is SupportTeam &&
        teamID == other.teamID &&
        teamName == other.teamName &&
        description == other.description &&
        managerId == other.managerId &&
        manager == other.manager &&
        teamMembers == other.teamMembers &&
        assignedTickets == other.assignedTickets;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, teamID.hashCode);
    _$hash = $jc(_$hash, teamName.hashCode);
    _$hash = $jc(_$hash, description.hashCode);
    _$hash = $jc(_$hash, managerId.hashCode);
    _$hash = $jc(_$hash, manager.hashCode);
    _$hash = $jc(_$hash, teamMembers.hashCode);
    _$hash = $jc(_$hash, assignedTickets.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'SupportTeam')
          ..add('teamID', teamID)
          ..add('teamName', teamName)
          ..add('description', description)
          ..add('managerId', managerId)
          ..add('manager', manager)
          ..add('teamMembers', teamMembers)
          ..add('assignedTickets', assignedTickets))
        .toString();
  }
}

class SupportTeamBuilder implements Builder<SupportTeam, SupportTeamBuilder> {
  _$SupportTeam? _$v;

  int? _teamID;
  int? get teamID => _$this._teamID;
  set teamID(int? teamID) => _$this._teamID = teamID;

  String? _teamName;
  String? get teamName => _$this._teamName;
  set teamName(String? teamName) => _$this._teamName = teamName;

  String? _description;
  String? get description => _$this._description;
  set description(String? description) => _$this._description = description;

  String? _managerId;
  String? get managerId => _$this._managerId;
  set managerId(String? managerId) => _$this._managerId = managerId;

  UserBuilder? _manager;
  UserBuilder get manager => _$this._manager ??= new UserBuilder();
  set manager(UserBuilder? manager) => _$this._manager = manager;

  ListBuilder<TeamMember>? _teamMembers;
  ListBuilder<TeamMember> get teamMembers =>
      _$this._teamMembers ??= new ListBuilder<TeamMember>();
  set teamMembers(ListBuilder<TeamMember>? teamMembers) =>
      _$this._teamMembers = teamMembers;

  ListBuilder<Ticket>? _assignedTickets;
  ListBuilder<Ticket> get assignedTickets =>
      _$this._assignedTickets ??= new ListBuilder<Ticket>();
  set assignedTickets(ListBuilder<Ticket>? assignedTickets) =>
      _$this._assignedTickets = assignedTickets;

  SupportTeamBuilder() {
    SupportTeam._defaults(this);
  }

  SupportTeamBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _teamID = $v.teamID;
      _teamName = $v.teamName;
      _description = $v.description;
      _managerId = $v.managerId;
      _manager = $v.manager?.toBuilder();
      _teamMembers = $v.teamMembers?.toBuilder();
      _assignedTickets = $v.assignedTickets?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(SupportTeam other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$SupportTeam;
  }

  @override
  void update(void Function(SupportTeamBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  SupportTeam build() => _build();

  _$SupportTeam _build() {
    _$SupportTeam _$result;
    try {
      _$result = _$v ??
          new _$SupportTeam._(
            teamID: teamID,
            teamName: BuiltValueNullFieldError.checkNotNull(
                teamName, r'SupportTeam', 'teamName'),
            description: description,
            managerId: managerId,
            manager: _manager?.build(),
            teamMembers: _teamMembers?.build(),
            assignedTickets: _assignedTickets?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'manager';
        _manager?.build();
        _$failedField = 'teamMembers';
        _teamMembers?.build();
        _$failedField = 'assignedTickets';
        _assignedTickets?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'SupportTeam', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
