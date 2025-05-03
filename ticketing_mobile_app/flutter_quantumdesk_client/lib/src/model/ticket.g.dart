// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$Ticket extends Ticket {
  @override
  final int? ticketID;
  @override
  final String title;
  @override
  final String description;
  @override
  final TicketCategory category;
  @override
  final TicketPriority priority;
  @override
  final TicketStatus status;
  @override
  final String createdByUserId;
  @override
  final String? assignedToUserId;
  @override
  final int? assignedToTeamID;
  @override
  final DateTime? createdDate;
  @override
  final DateTime? updatedDate;
  @override
  final DateTime? dueDate;
  @override
  final DateTime? resolutionDate;
  @override
  final DateTime? closedDate;
  @override
  final String source_;
  @override
  final bool? isEscalated;
  @override
  final User? createdByUser;
  @override
  final User? assignedToUser;
  @override
  final SupportTeam? assignedToTeam;
  @override
  final BuiltList<TicketHistory>? ticketHistories;
  @override
  final BuiltList<TicketComment>? ticketComments;
  @override
  final BuiltList<Attachment>? ticketAttachments;

  factory _$Ticket([void Function(TicketBuilder)? updates]) =>
      (new TicketBuilder()..update(updates))._build();

  _$Ticket._(
      {this.ticketID,
      required this.title,
      required this.description,
      required this.category,
      required this.priority,
      required this.status,
      required this.createdByUserId,
      this.assignedToUserId,
      this.assignedToTeamID,
      this.createdDate,
      this.updatedDate,
      this.dueDate,
      this.resolutionDate,
      this.closedDate,
      required this.source_,
      this.isEscalated,
      this.createdByUser,
      this.assignedToUser,
      this.assignedToTeam,
      this.ticketHistories,
      this.ticketComments,
      this.ticketAttachments})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(title, r'Ticket', 'title');
    BuiltValueNullFieldError.checkNotNull(
        description, r'Ticket', 'description');
    BuiltValueNullFieldError.checkNotNull(category, r'Ticket', 'category');
    BuiltValueNullFieldError.checkNotNull(priority, r'Ticket', 'priority');
    BuiltValueNullFieldError.checkNotNull(status, r'Ticket', 'status');
    BuiltValueNullFieldError.checkNotNull(
        createdByUserId, r'Ticket', 'createdByUserId');
    BuiltValueNullFieldError.checkNotNull(source_, r'Ticket', 'source_');
  }

  @override
  Ticket rebuild(void Function(TicketBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  TicketBuilder toBuilder() => new TicketBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is Ticket &&
        ticketID == other.ticketID &&
        title == other.title &&
        description == other.description &&
        category == other.category &&
        priority == other.priority &&
        status == other.status &&
        createdByUserId == other.createdByUserId &&
        assignedToUserId == other.assignedToUserId &&
        assignedToTeamID == other.assignedToTeamID &&
        createdDate == other.createdDate &&
        updatedDate == other.updatedDate &&
        dueDate == other.dueDate &&
        resolutionDate == other.resolutionDate &&
        closedDate == other.closedDate &&
        source_ == other.source_ &&
        isEscalated == other.isEscalated &&
        createdByUser == other.createdByUser &&
        assignedToUser == other.assignedToUser &&
        assignedToTeam == other.assignedToTeam &&
        ticketHistories == other.ticketHistories &&
        ticketComments == other.ticketComments &&
        ticketAttachments == other.ticketAttachments;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, ticketID.hashCode);
    _$hash = $jc(_$hash, title.hashCode);
    _$hash = $jc(_$hash, description.hashCode);
    _$hash = $jc(_$hash, category.hashCode);
    _$hash = $jc(_$hash, priority.hashCode);
    _$hash = $jc(_$hash, status.hashCode);
    _$hash = $jc(_$hash, createdByUserId.hashCode);
    _$hash = $jc(_$hash, assignedToUserId.hashCode);
    _$hash = $jc(_$hash, assignedToTeamID.hashCode);
    _$hash = $jc(_$hash, createdDate.hashCode);
    _$hash = $jc(_$hash, updatedDate.hashCode);
    _$hash = $jc(_$hash, dueDate.hashCode);
    _$hash = $jc(_$hash, resolutionDate.hashCode);
    _$hash = $jc(_$hash, closedDate.hashCode);
    _$hash = $jc(_$hash, source_.hashCode);
    _$hash = $jc(_$hash, isEscalated.hashCode);
    _$hash = $jc(_$hash, createdByUser.hashCode);
    _$hash = $jc(_$hash, assignedToUser.hashCode);
    _$hash = $jc(_$hash, assignedToTeam.hashCode);
    _$hash = $jc(_$hash, ticketHistories.hashCode);
    _$hash = $jc(_$hash, ticketComments.hashCode);
    _$hash = $jc(_$hash, ticketAttachments.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'Ticket')
          ..add('ticketID', ticketID)
          ..add('title', title)
          ..add('description', description)
          ..add('category', category)
          ..add('priority', priority)
          ..add('status', status)
          ..add('createdByUserId', createdByUserId)
          ..add('assignedToUserId', assignedToUserId)
          ..add('assignedToTeamID', assignedToTeamID)
          ..add('createdDate', createdDate)
          ..add('updatedDate', updatedDate)
          ..add('dueDate', dueDate)
          ..add('resolutionDate', resolutionDate)
          ..add('closedDate', closedDate)
          ..add('source_', source_)
          ..add('isEscalated', isEscalated)
          ..add('createdByUser', createdByUser)
          ..add('assignedToUser', assignedToUser)
          ..add('assignedToTeam', assignedToTeam)
          ..add('ticketHistories', ticketHistories)
          ..add('ticketComments', ticketComments)
          ..add('ticketAttachments', ticketAttachments))
        .toString();
  }
}

class TicketBuilder implements Builder<Ticket, TicketBuilder> {
  _$Ticket? _$v;

  int? _ticketID;
  int? get ticketID => _$this._ticketID;
  set ticketID(int? ticketID) => _$this._ticketID = ticketID;

  String? _title;
  String? get title => _$this._title;
  set title(String? title) => _$this._title = title;

  String? _description;
  String? get description => _$this._description;
  set description(String? description) => _$this._description = description;

  TicketCategory? _category;
  TicketCategory? get category => _$this._category;
  set category(TicketCategory? category) => _$this._category = category;

  TicketPriority? _priority;
  TicketPriority? get priority => _$this._priority;
  set priority(TicketPriority? priority) => _$this._priority = priority;

  TicketStatus? _status;
  TicketStatus? get status => _$this._status;
  set status(TicketStatus? status) => _$this._status = status;

  String? _createdByUserId;
  String? get createdByUserId => _$this._createdByUserId;
  set createdByUserId(String? createdByUserId) =>
      _$this._createdByUserId = createdByUserId;

  String? _assignedToUserId;
  String? get assignedToUserId => _$this._assignedToUserId;
  set assignedToUserId(String? assignedToUserId) =>
      _$this._assignedToUserId = assignedToUserId;

  int? _assignedToTeamID;
  int? get assignedToTeamID => _$this._assignedToTeamID;
  set assignedToTeamID(int? assignedToTeamID) =>
      _$this._assignedToTeamID = assignedToTeamID;

  DateTime? _createdDate;
  DateTime? get createdDate => _$this._createdDate;
  set createdDate(DateTime? createdDate) => _$this._createdDate = createdDate;

  DateTime? _updatedDate;
  DateTime? get updatedDate => _$this._updatedDate;
  set updatedDate(DateTime? updatedDate) => _$this._updatedDate = updatedDate;

  DateTime? _dueDate;
  DateTime? get dueDate => _$this._dueDate;
  set dueDate(DateTime? dueDate) => _$this._dueDate = dueDate;

  DateTime? _resolutionDate;
  DateTime? get resolutionDate => _$this._resolutionDate;
  set resolutionDate(DateTime? resolutionDate) =>
      _$this._resolutionDate = resolutionDate;

  DateTime? _closedDate;
  DateTime? get closedDate => _$this._closedDate;
  set closedDate(DateTime? closedDate) => _$this._closedDate = closedDate;

  String? _source_;
  String? get source_ => _$this._source_;
  set source_(String? source_) => _$this._source_ = source_;

  bool? _isEscalated;
  bool? get isEscalated => _$this._isEscalated;
  set isEscalated(bool? isEscalated) => _$this._isEscalated = isEscalated;

  UserBuilder? _createdByUser;
  UserBuilder get createdByUser => _$this._createdByUser ??= new UserBuilder();
  set createdByUser(UserBuilder? createdByUser) =>
      _$this._createdByUser = createdByUser;

  UserBuilder? _assignedToUser;
  UserBuilder get assignedToUser =>
      _$this._assignedToUser ??= new UserBuilder();
  set assignedToUser(UserBuilder? assignedToUser) =>
      _$this._assignedToUser = assignedToUser;

  SupportTeamBuilder? _assignedToTeam;
  SupportTeamBuilder get assignedToTeam =>
      _$this._assignedToTeam ??= new SupportTeamBuilder();
  set assignedToTeam(SupportTeamBuilder? assignedToTeam) =>
      _$this._assignedToTeam = assignedToTeam;

  ListBuilder<TicketHistory>? _ticketHistories;
  ListBuilder<TicketHistory> get ticketHistories =>
      _$this._ticketHistories ??= new ListBuilder<TicketHistory>();
  set ticketHistories(ListBuilder<TicketHistory>? ticketHistories) =>
      _$this._ticketHistories = ticketHistories;

  ListBuilder<TicketComment>? _ticketComments;
  ListBuilder<TicketComment> get ticketComments =>
      _$this._ticketComments ??= new ListBuilder<TicketComment>();
  set ticketComments(ListBuilder<TicketComment>? ticketComments) =>
      _$this._ticketComments = ticketComments;

  ListBuilder<Attachment>? _ticketAttachments;
  ListBuilder<Attachment> get ticketAttachments =>
      _$this._ticketAttachments ??= new ListBuilder<Attachment>();
  set ticketAttachments(ListBuilder<Attachment>? ticketAttachments) =>
      _$this._ticketAttachments = ticketAttachments;

  TicketBuilder() {
    Ticket._defaults(this);
  }

  TicketBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _ticketID = $v.ticketID;
      _title = $v.title;
      _description = $v.description;
      _category = $v.category;
      _priority = $v.priority;
      _status = $v.status;
      _createdByUserId = $v.createdByUserId;
      _assignedToUserId = $v.assignedToUserId;
      _assignedToTeamID = $v.assignedToTeamID;
      _createdDate = $v.createdDate;
      _updatedDate = $v.updatedDate;
      _dueDate = $v.dueDate;
      _resolutionDate = $v.resolutionDate;
      _closedDate = $v.closedDate;
      _source_ = $v.source_;
      _isEscalated = $v.isEscalated;
      _createdByUser = $v.createdByUser?.toBuilder();
      _assignedToUser = $v.assignedToUser?.toBuilder();
      _assignedToTeam = $v.assignedToTeam?.toBuilder();
      _ticketHistories = $v.ticketHistories?.toBuilder();
      _ticketComments = $v.ticketComments?.toBuilder();
      _ticketAttachments = $v.ticketAttachments?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(Ticket other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$Ticket;
  }

  @override
  void update(void Function(TicketBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  Ticket build() => _build();

  _$Ticket _build() {
    _$Ticket _$result;
    try {
      _$result = _$v ??
          new _$Ticket._(
            ticketID: ticketID,
            title: BuiltValueNullFieldError.checkNotNull(
                title, r'Ticket', 'title'),
            description: BuiltValueNullFieldError.checkNotNull(
                description, r'Ticket', 'description'),
            category: BuiltValueNullFieldError.checkNotNull(
                category, r'Ticket', 'category'),
            priority: BuiltValueNullFieldError.checkNotNull(
                priority, r'Ticket', 'priority'),
            status: BuiltValueNullFieldError.checkNotNull(
                status, r'Ticket', 'status'),
            createdByUserId: BuiltValueNullFieldError.checkNotNull(
                createdByUserId, r'Ticket', 'createdByUserId'),
            assignedToUserId: assignedToUserId,
            assignedToTeamID: assignedToTeamID,
            createdDate: createdDate,
            updatedDate: updatedDate,
            dueDate: dueDate,
            resolutionDate: resolutionDate,
            closedDate: closedDate,
            source_: BuiltValueNullFieldError.checkNotNull(
                source_, r'Ticket', 'source_'),
            isEscalated: isEscalated,
            createdByUser: _createdByUser?.build(),
            assignedToUser: _assignedToUser?.build(),
            assignedToTeam: _assignedToTeam?.build(),
            ticketHistories: _ticketHistories?.build(),
            ticketComments: _ticketComments?.build(),
            ticketAttachments: _ticketAttachments?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'createdByUser';
        _createdByUser?.build();
        _$failedField = 'assignedToUser';
        _assignedToUser?.build();
        _$failedField = 'assignedToTeam';
        _assignedToTeam?.build();
        _$failedField = 'ticketHistories';
        _ticketHistories?.build();
        _$failedField = 'ticketComments';
        _ticketComments?.build();
        _$failedField = 'ticketAttachments';
        _ticketAttachments?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'Ticket', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
