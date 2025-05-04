// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'team_member.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$TeamMember extends TeamMember {
  @override
  final int? teamMemberID;
  @override
  final int teamID;
  @override
  final String userId;
  @override
  final DateTime? joinDate;
  @override
  final SupportTeam? team;
  @override
  final User? user;

  factory _$TeamMember([void Function(TeamMemberBuilder)? updates]) =>
      (new TeamMemberBuilder()..update(updates))._build();

  _$TeamMember._(
      {this.teamMemberID,
      required this.teamID,
      required this.userId,
      this.joinDate,
      this.team,
      this.user})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(teamID, r'TeamMember', 'teamID');
    BuiltValueNullFieldError.checkNotNull(userId, r'TeamMember', 'userId');
  }

  @override
  TeamMember rebuild(void Function(TeamMemberBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  TeamMemberBuilder toBuilder() => new TeamMemberBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is TeamMember &&
        teamMemberID == other.teamMemberID &&
        teamID == other.teamID &&
        userId == other.userId &&
        joinDate == other.joinDate &&
        team == other.team &&
        user == other.user;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, teamMemberID.hashCode);
    _$hash = $jc(_$hash, teamID.hashCode);
    _$hash = $jc(_$hash, userId.hashCode);
    _$hash = $jc(_$hash, joinDate.hashCode);
    _$hash = $jc(_$hash, team.hashCode);
    _$hash = $jc(_$hash, user.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'TeamMember')
          ..add('teamMemberID', teamMemberID)
          ..add('teamID', teamID)
          ..add('userId', userId)
          ..add('joinDate', joinDate)
          ..add('team', team)
          ..add('user', user))
        .toString();
  }
}

class TeamMemberBuilder implements Builder<TeamMember, TeamMemberBuilder> {
  _$TeamMember? _$v;

  int? _teamMemberID;
  int? get teamMemberID => _$this._teamMemberID;
  set teamMemberID(int? teamMemberID) => _$this._teamMemberID = teamMemberID;

  int? _teamID;
  int? get teamID => _$this._teamID;
  set teamID(int? teamID) => _$this._teamID = teamID;

  String? _userId;
  String? get userId => _$this._userId;
  set userId(String? userId) => _$this._userId = userId;

  DateTime? _joinDate;
  DateTime? get joinDate => _$this._joinDate;
  set joinDate(DateTime? joinDate) => _$this._joinDate = joinDate;

  SupportTeamBuilder? _team;
  SupportTeamBuilder get team => _$this._team ??= new SupportTeamBuilder();
  set team(SupportTeamBuilder? team) => _$this._team = team;

  UserBuilder? _user;
  UserBuilder get user => _$this._user ??= new UserBuilder();
  set user(UserBuilder? user) => _$this._user = user;

  TeamMemberBuilder() {
    TeamMember._defaults(this);
  }

  TeamMemberBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _teamMemberID = $v.teamMemberID;
      _teamID = $v.teamID;
      _userId = $v.userId;
      _joinDate = $v.joinDate;
      _team = $v.team?.toBuilder();
      _user = $v.user?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(TeamMember other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$TeamMember;
  }

  @override
  void update(void Function(TeamMemberBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  TeamMember build() => _build();

  _$TeamMember _build() {
    _$TeamMember _$result;
    try {
      _$result = _$v ??
          new _$TeamMember._(
            teamMemberID: teamMemberID,
            teamID: BuiltValueNullFieldError.checkNotNull(
                teamID, r'TeamMember', 'teamID'),
            userId: BuiltValueNullFieldError.checkNotNull(
                userId, r'TeamMember', 'userId'),
            joinDate: joinDate,
            team: _team?.build(),
            user: _user?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'team';
        _team?.build();
        _$failedField = 'user';
        _user?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'TeamMember', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
