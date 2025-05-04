// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket_comment.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$TicketComment extends TicketComment {
  @override
  final int? commentID;
  @override
  final int ticketID;
  @override
  final String userId;
  @override
  final String commentText;
  @override
  final bool? isInternal;
  @override
  final DateTime? createdDate;
  @override
  final Ticket? ticket;
  @override
  final User? user;

  factory _$TicketComment([void Function(TicketCommentBuilder)? updates]) =>
      (new TicketCommentBuilder()..update(updates))._build();

  _$TicketComment._(
      {this.commentID,
      required this.ticketID,
      required this.userId,
      required this.commentText,
      this.isInternal,
      this.createdDate,
      this.ticket,
      this.user})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(
        ticketID, r'TicketComment', 'ticketID');
    BuiltValueNullFieldError.checkNotNull(userId, r'TicketComment', 'userId');
    BuiltValueNullFieldError.checkNotNull(
        commentText, r'TicketComment', 'commentText');
  }

  @override
  TicketComment rebuild(void Function(TicketCommentBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  TicketCommentBuilder toBuilder() => new TicketCommentBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is TicketComment &&
        commentID == other.commentID &&
        ticketID == other.ticketID &&
        userId == other.userId &&
        commentText == other.commentText &&
        isInternal == other.isInternal &&
        createdDate == other.createdDate &&
        ticket == other.ticket &&
        user == other.user;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, commentID.hashCode);
    _$hash = $jc(_$hash, ticketID.hashCode);
    _$hash = $jc(_$hash, userId.hashCode);
    _$hash = $jc(_$hash, commentText.hashCode);
    _$hash = $jc(_$hash, isInternal.hashCode);
    _$hash = $jc(_$hash, createdDate.hashCode);
    _$hash = $jc(_$hash, ticket.hashCode);
    _$hash = $jc(_$hash, user.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'TicketComment')
          ..add('commentID', commentID)
          ..add('ticketID', ticketID)
          ..add('userId', userId)
          ..add('commentText', commentText)
          ..add('isInternal', isInternal)
          ..add('createdDate', createdDate)
          ..add('ticket', ticket)
          ..add('user', user))
        .toString();
  }
}

class TicketCommentBuilder
    implements Builder<TicketComment, TicketCommentBuilder> {
  _$TicketComment? _$v;

  int? _commentID;
  int? get commentID => _$this._commentID;
  set commentID(int? commentID) => _$this._commentID = commentID;

  int? _ticketID;
  int? get ticketID => _$this._ticketID;
  set ticketID(int? ticketID) => _$this._ticketID = ticketID;

  String? _userId;
  String? get userId => _$this._userId;
  set userId(String? userId) => _$this._userId = userId;

  String? _commentText;
  String? get commentText => _$this._commentText;
  set commentText(String? commentText) => _$this._commentText = commentText;

  bool? _isInternal;
  bool? get isInternal => _$this._isInternal;
  set isInternal(bool? isInternal) => _$this._isInternal = isInternal;

  DateTime? _createdDate;
  DateTime? get createdDate => _$this._createdDate;
  set createdDate(DateTime? createdDate) => _$this._createdDate = createdDate;

  TicketBuilder? _ticket;
  TicketBuilder get ticket => _$this._ticket ??= new TicketBuilder();
  set ticket(TicketBuilder? ticket) => _$this._ticket = ticket;

  UserBuilder? _user;
  UserBuilder get user => _$this._user ??= new UserBuilder();
  set user(UserBuilder? user) => _$this._user = user;

  TicketCommentBuilder() {
    TicketComment._defaults(this);
  }

  TicketCommentBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _commentID = $v.commentID;
      _ticketID = $v.ticketID;
      _userId = $v.userId;
      _commentText = $v.commentText;
      _isInternal = $v.isInternal;
      _createdDate = $v.createdDate;
      _ticket = $v.ticket?.toBuilder();
      _user = $v.user?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(TicketComment other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$TicketComment;
  }

  @override
  void update(void Function(TicketCommentBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  TicketComment build() => _build();

  _$TicketComment _build() {
    _$TicketComment _$result;
    try {
      _$result = _$v ??
          new _$TicketComment._(
            commentID: commentID,
            ticketID: BuiltValueNullFieldError.checkNotNull(
                ticketID, r'TicketComment', 'ticketID'),
            userId: BuiltValueNullFieldError.checkNotNull(
                userId, r'TicketComment', 'userId'),
            commentText: BuiltValueNullFieldError.checkNotNull(
                commentText, r'TicketComment', 'commentText'),
            isInternal: isInternal,
            createdDate: createdDate,
            ticket: _ticket?.build(),
            user: _user?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'ticket';
        _ticket?.build();
        _$failedField = 'user';
        _user?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'TicketComment', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
