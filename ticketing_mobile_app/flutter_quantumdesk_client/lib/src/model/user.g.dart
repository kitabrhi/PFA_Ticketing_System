// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$User extends User {
  @override
  final String? id;
  @override
  final String? userName;
  @override
  final String? normalizedUserName;
  @override
  final String? email;
  @override
  final String? normalizedEmail;
  @override
  final bool? emailConfirmed;
  @override
  final String? passwordHash;
  @override
  final String? securityStamp;
  @override
  final String? concurrencyStamp;
  @override
  final String? phoneNumber;
  @override
  final bool? phoneNumberConfirmed;
  @override
  final bool? twoFactorEnabled;
  @override
  final DateTime? lockoutEnd;
  @override
  final bool? lockoutEnabled;
  @override
  final int? accessFailedCount;
  @override
  final String? firstName;
  @override
  final String? lastName;
  @override
  final DateTime createdDate;
  @override
  final DateTime? lastLoginDate;
  @override
  final bool isActive;
  @override
  final BuiltList<Ticket>? createdTickets;
  @override
  final BuiltList<Ticket>? assignedTickets;
  @override
  final BuiltList<SupportTeam>? managedTeams;
  @override
  final BuiltList<TeamMember>? teamMemberships;
  @override
  final BuiltList<TicketComment>? comments;
  @override
  final BuiltList<Attachment>? attachments;
  @override
  final BuiltList<TicketHistory>? ticketChanges;
  @override
  final BuiltList<KnowledgeBaseArticle>? articles;
  @override
  final BuiltList<Notification>? notifications;

  factory _$User([void Function(UserBuilder)? updates]) =>
      (new UserBuilder()..update(updates))._build();

  _$User._(
      {this.id,
      this.userName,
      this.normalizedUserName,
      this.email,
      this.normalizedEmail,
      this.emailConfirmed,
      this.passwordHash,
      this.securityStamp,
      this.concurrencyStamp,
      this.phoneNumber,
      this.phoneNumberConfirmed,
      this.twoFactorEnabled,
      this.lockoutEnd,
      this.lockoutEnabled,
      this.accessFailedCount,
      this.firstName,
      this.lastName,
      required this.createdDate,
      this.lastLoginDate,
      required this.isActive,
      this.createdTickets,
      this.assignedTickets,
      this.managedTeams,
      this.teamMemberships,
      this.comments,
      this.attachments,
      this.ticketChanges,
      this.articles,
      this.notifications})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(createdDate, r'User', 'createdDate');
    BuiltValueNullFieldError.checkNotNull(isActive, r'User', 'isActive');
  }

  @override
  User rebuild(void Function(UserBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  UserBuilder toBuilder() => new UserBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is User &&
        id == other.id &&
        userName == other.userName &&
        normalizedUserName == other.normalizedUserName &&
        email == other.email &&
        normalizedEmail == other.normalizedEmail &&
        emailConfirmed == other.emailConfirmed &&
        passwordHash == other.passwordHash &&
        securityStamp == other.securityStamp &&
        concurrencyStamp == other.concurrencyStamp &&
        phoneNumber == other.phoneNumber &&
        phoneNumberConfirmed == other.phoneNumberConfirmed &&
        twoFactorEnabled == other.twoFactorEnabled &&
        lockoutEnd == other.lockoutEnd &&
        lockoutEnabled == other.lockoutEnabled &&
        accessFailedCount == other.accessFailedCount &&
        firstName == other.firstName &&
        lastName == other.lastName &&
        createdDate == other.createdDate &&
        lastLoginDate == other.lastLoginDate &&
        isActive == other.isActive &&
        createdTickets == other.createdTickets &&
        assignedTickets == other.assignedTickets &&
        managedTeams == other.managedTeams &&
        teamMemberships == other.teamMemberships &&
        comments == other.comments &&
        attachments == other.attachments &&
        ticketChanges == other.ticketChanges &&
        articles == other.articles &&
        notifications == other.notifications;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, id.hashCode);
    _$hash = $jc(_$hash, userName.hashCode);
    _$hash = $jc(_$hash, normalizedUserName.hashCode);
    _$hash = $jc(_$hash, email.hashCode);
    _$hash = $jc(_$hash, normalizedEmail.hashCode);
    _$hash = $jc(_$hash, emailConfirmed.hashCode);
    _$hash = $jc(_$hash, passwordHash.hashCode);
    _$hash = $jc(_$hash, securityStamp.hashCode);
    _$hash = $jc(_$hash, concurrencyStamp.hashCode);
    _$hash = $jc(_$hash, phoneNumber.hashCode);
    _$hash = $jc(_$hash, phoneNumberConfirmed.hashCode);
    _$hash = $jc(_$hash, twoFactorEnabled.hashCode);
    _$hash = $jc(_$hash, lockoutEnd.hashCode);
    _$hash = $jc(_$hash, lockoutEnabled.hashCode);
    _$hash = $jc(_$hash, accessFailedCount.hashCode);
    _$hash = $jc(_$hash, firstName.hashCode);
    _$hash = $jc(_$hash, lastName.hashCode);
    _$hash = $jc(_$hash, createdDate.hashCode);
    _$hash = $jc(_$hash, lastLoginDate.hashCode);
    _$hash = $jc(_$hash, isActive.hashCode);
    _$hash = $jc(_$hash, createdTickets.hashCode);
    _$hash = $jc(_$hash, assignedTickets.hashCode);
    _$hash = $jc(_$hash, managedTeams.hashCode);
    _$hash = $jc(_$hash, teamMemberships.hashCode);
    _$hash = $jc(_$hash, comments.hashCode);
    _$hash = $jc(_$hash, attachments.hashCode);
    _$hash = $jc(_$hash, ticketChanges.hashCode);
    _$hash = $jc(_$hash, articles.hashCode);
    _$hash = $jc(_$hash, notifications.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'User')
          ..add('id', id)
          ..add('userName', userName)
          ..add('normalizedUserName', normalizedUserName)
          ..add('email', email)
          ..add('normalizedEmail', normalizedEmail)
          ..add('emailConfirmed', emailConfirmed)
          ..add('passwordHash', passwordHash)
          ..add('securityStamp', securityStamp)
          ..add('concurrencyStamp', concurrencyStamp)
          ..add('phoneNumber', phoneNumber)
          ..add('phoneNumberConfirmed', phoneNumberConfirmed)
          ..add('twoFactorEnabled', twoFactorEnabled)
          ..add('lockoutEnd', lockoutEnd)
          ..add('lockoutEnabled', lockoutEnabled)
          ..add('accessFailedCount', accessFailedCount)
          ..add('firstName', firstName)
          ..add('lastName', lastName)
          ..add('createdDate', createdDate)
          ..add('lastLoginDate', lastLoginDate)
          ..add('isActive', isActive)
          ..add('createdTickets', createdTickets)
          ..add('assignedTickets', assignedTickets)
          ..add('managedTeams', managedTeams)
          ..add('teamMemberships', teamMemberships)
          ..add('comments', comments)
          ..add('attachments', attachments)
          ..add('ticketChanges', ticketChanges)
          ..add('articles', articles)
          ..add('notifications', notifications))
        .toString();
  }
}

class UserBuilder implements Builder<User, UserBuilder> {
  _$User? _$v;

  String? _id;
  String? get id => _$this._id;
  set id(String? id) => _$this._id = id;

  String? _userName;
  String? get userName => _$this._userName;
  set userName(String? userName) => _$this._userName = userName;

  String? _normalizedUserName;
  String? get normalizedUserName => _$this._normalizedUserName;
  set normalizedUserName(String? normalizedUserName) =>
      _$this._normalizedUserName = normalizedUserName;

  String? _email;
  String? get email => _$this._email;
  set email(String? email) => _$this._email = email;

  String? _normalizedEmail;
  String? get normalizedEmail => _$this._normalizedEmail;
  set normalizedEmail(String? normalizedEmail) =>
      _$this._normalizedEmail = normalizedEmail;

  bool? _emailConfirmed;
  bool? get emailConfirmed => _$this._emailConfirmed;
  set emailConfirmed(bool? emailConfirmed) =>
      _$this._emailConfirmed = emailConfirmed;

  String? _passwordHash;
  String? get passwordHash => _$this._passwordHash;
  set passwordHash(String? passwordHash) => _$this._passwordHash = passwordHash;

  String? _securityStamp;
  String? get securityStamp => _$this._securityStamp;
  set securityStamp(String? securityStamp) =>
      _$this._securityStamp = securityStamp;

  String? _concurrencyStamp;
  String? get concurrencyStamp => _$this._concurrencyStamp;
  set concurrencyStamp(String? concurrencyStamp) =>
      _$this._concurrencyStamp = concurrencyStamp;

  String? _phoneNumber;
  String? get phoneNumber => _$this._phoneNumber;
  set phoneNumber(String? phoneNumber) => _$this._phoneNumber = phoneNumber;

  bool? _phoneNumberConfirmed;
  bool? get phoneNumberConfirmed => _$this._phoneNumberConfirmed;
  set phoneNumberConfirmed(bool? phoneNumberConfirmed) =>
      _$this._phoneNumberConfirmed = phoneNumberConfirmed;

  bool? _twoFactorEnabled;
  bool? get twoFactorEnabled => _$this._twoFactorEnabled;
  set twoFactorEnabled(bool? twoFactorEnabled) =>
      _$this._twoFactorEnabled = twoFactorEnabled;

  DateTime? _lockoutEnd;
  DateTime? get lockoutEnd => _$this._lockoutEnd;
  set lockoutEnd(DateTime? lockoutEnd) => _$this._lockoutEnd = lockoutEnd;

  bool? _lockoutEnabled;
  bool? get lockoutEnabled => _$this._lockoutEnabled;
  set lockoutEnabled(bool? lockoutEnabled) =>
      _$this._lockoutEnabled = lockoutEnabled;

  int? _accessFailedCount;
  int? get accessFailedCount => _$this._accessFailedCount;
  set accessFailedCount(int? accessFailedCount) =>
      _$this._accessFailedCount = accessFailedCount;

  String? _firstName;
  String? get firstName => _$this._firstName;
  set firstName(String? firstName) => _$this._firstName = firstName;

  String? _lastName;
  String? get lastName => _$this._lastName;
  set lastName(String? lastName) => _$this._lastName = lastName;

  DateTime? _createdDate;
  DateTime? get createdDate => _$this._createdDate;
  set createdDate(DateTime? createdDate) => _$this._createdDate = createdDate;

  DateTime? _lastLoginDate;
  DateTime? get lastLoginDate => _$this._lastLoginDate;
  set lastLoginDate(DateTime? lastLoginDate) =>
      _$this._lastLoginDate = lastLoginDate;

  bool? _isActive;
  bool? get isActive => _$this._isActive;
  set isActive(bool? isActive) => _$this._isActive = isActive;

  ListBuilder<Ticket>? _createdTickets;
  ListBuilder<Ticket> get createdTickets =>
      _$this._createdTickets ??= new ListBuilder<Ticket>();
  set createdTickets(ListBuilder<Ticket>? createdTickets) =>
      _$this._createdTickets = createdTickets;

  ListBuilder<Ticket>? _assignedTickets;
  ListBuilder<Ticket> get assignedTickets =>
      _$this._assignedTickets ??= new ListBuilder<Ticket>();
  set assignedTickets(ListBuilder<Ticket>? assignedTickets) =>
      _$this._assignedTickets = assignedTickets;

  ListBuilder<SupportTeam>? _managedTeams;
  ListBuilder<SupportTeam> get managedTeams =>
      _$this._managedTeams ??= new ListBuilder<SupportTeam>();
  set managedTeams(ListBuilder<SupportTeam>? managedTeams) =>
      _$this._managedTeams = managedTeams;

  ListBuilder<TeamMember>? _teamMemberships;
  ListBuilder<TeamMember> get teamMemberships =>
      _$this._teamMemberships ??= new ListBuilder<TeamMember>();
  set teamMemberships(ListBuilder<TeamMember>? teamMemberships) =>
      _$this._teamMemberships = teamMemberships;

  ListBuilder<TicketComment>? _comments;
  ListBuilder<TicketComment> get comments =>
      _$this._comments ??= new ListBuilder<TicketComment>();
  set comments(ListBuilder<TicketComment>? comments) =>
      _$this._comments = comments;

  ListBuilder<Attachment>? _attachments;
  ListBuilder<Attachment> get attachments =>
      _$this._attachments ??= new ListBuilder<Attachment>();
  set attachments(ListBuilder<Attachment>? attachments) =>
      _$this._attachments = attachments;

  ListBuilder<TicketHistory>? _ticketChanges;
  ListBuilder<TicketHistory> get ticketChanges =>
      _$this._ticketChanges ??= new ListBuilder<TicketHistory>();
  set ticketChanges(ListBuilder<TicketHistory>? ticketChanges) =>
      _$this._ticketChanges = ticketChanges;

  ListBuilder<KnowledgeBaseArticle>? _articles;
  ListBuilder<KnowledgeBaseArticle> get articles =>
      _$this._articles ??= new ListBuilder<KnowledgeBaseArticle>();
  set articles(ListBuilder<KnowledgeBaseArticle>? articles) =>
      _$this._articles = articles;

  ListBuilder<Notification>? _notifications;
  ListBuilder<Notification> get notifications =>
      _$this._notifications ??= new ListBuilder<Notification>();
  set notifications(ListBuilder<Notification>? notifications) =>
      _$this._notifications = notifications;

  UserBuilder() {
    User._defaults(this);
  }

  UserBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _id = $v.id;
      _userName = $v.userName;
      _normalizedUserName = $v.normalizedUserName;
      _email = $v.email;
      _normalizedEmail = $v.normalizedEmail;
      _emailConfirmed = $v.emailConfirmed;
      _passwordHash = $v.passwordHash;
      _securityStamp = $v.securityStamp;
      _concurrencyStamp = $v.concurrencyStamp;
      _phoneNumber = $v.phoneNumber;
      _phoneNumberConfirmed = $v.phoneNumberConfirmed;
      _twoFactorEnabled = $v.twoFactorEnabled;
      _lockoutEnd = $v.lockoutEnd;
      _lockoutEnabled = $v.lockoutEnabled;
      _accessFailedCount = $v.accessFailedCount;
      _firstName = $v.firstName;
      _lastName = $v.lastName;
      _createdDate = $v.createdDate;
      _lastLoginDate = $v.lastLoginDate;
      _isActive = $v.isActive;
      _createdTickets = $v.createdTickets?.toBuilder();
      _assignedTickets = $v.assignedTickets?.toBuilder();
      _managedTeams = $v.managedTeams?.toBuilder();
      _teamMemberships = $v.teamMemberships?.toBuilder();
      _comments = $v.comments?.toBuilder();
      _attachments = $v.attachments?.toBuilder();
      _ticketChanges = $v.ticketChanges?.toBuilder();
      _articles = $v.articles?.toBuilder();
      _notifications = $v.notifications?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(User other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$User;
  }

  @override
  void update(void Function(UserBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  User build() => _build();

  _$User _build() {
    _$User _$result;
    try {
      _$result = _$v ??
          new _$User._(
            id: id,
            userName: userName,
            normalizedUserName: normalizedUserName,
            email: email,
            normalizedEmail: normalizedEmail,
            emailConfirmed: emailConfirmed,
            passwordHash: passwordHash,
            securityStamp: securityStamp,
            concurrencyStamp: concurrencyStamp,
            phoneNumber: phoneNumber,
            phoneNumberConfirmed: phoneNumberConfirmed,
            twoFactorEnabled: twoFactorEnabled,
            lockoutEnd: lockoutEnd,
            lockoutEnabled: lockoutEnabled,
            accessFailedCount: accessFailedCount,
            firstName: firstName,
            lastName: lastName,
            createdDate: BuiltValueNullFieldError.checkNotNull(
                createdDate, r'User', 'createdDate'),
            lastLoginDate: lastLoginDate,
            isActive: BuiltValueNullFieldError.checkNotNull(
                isActive, r'User', 'isActive'),
            createdTickets: _createdTickets?.build(),
            assignedTickets: _assignedTickets?.build(),
            managedTeams: _managedTeams?.build(),
            teamMemberships: _teamMemberships?.build(),
            comments: _comments?.build(),
            attachments: _attachments?.build(),
            ticketChanges: _ticketChanges?.build(),
            articles: _articles?.build(),
            notifications: _notifications?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'createdTickets';
        _createdTickets?.build();
        _$failedField = 'assignedTickets';
        _assignedTickets?.build();
        _$failedField = 'managedTeams';
        _managedTeams?.build();
        _$failedField = 'teamMemberships';
        _teamMemberships?.build();
        _$failedField = 'comments';
        _comments?.build();
        _$failedField = 'attachments';
        _attachments?.build();
        _$failedField = 'ticketChanges';
        _ticketChanges?.build();
        _$failedField = 'articles';
        _articles?.build();
        _$failedField = 'notifications';
        _notifications?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'User', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
