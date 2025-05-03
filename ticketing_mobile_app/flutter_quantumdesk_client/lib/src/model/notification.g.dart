// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'notification.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$Notification extends Notification {
  @override
  final int? notificationId;
  @override
  final String userId;
  @override
  final String title;
  @override
  final String message;
  @override
  final DateTime? dateSent;
  @override
  final bool? isRead;
  @override
  final User? user;

  factory _$Notification([void Function(NotificationBuilder)? updates]) =>
      (new NotificationBuilder()..update(updates))._build();

  _$Notification._(
      {this.notificationId,
      required this.userId,
      required this.title,
      required this.message,
      this.dateSent,
      this.isRead,
      this.user})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(userId, r'Notification', 'userId');
    BuiltValueNullFieldError.checkNotNull(title, r'Notification', 'title');
    BuiltValueNullFieldError.checkNotNull(message, r'Notification', 'message');
  }

  @override
  Notification rebuild(void Function(NotificationBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  NotificationBuilder toBuilder() => new NotificationBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is Notification &&
        notificationId == other.notificationId &&
        userId == other.userId &&
        title == other.title &&
        message == other.message &&
        dateSent == other.dateSent &&
        isRead == other.isRead &&
        user == other.user;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, notificationId.hashCode);
    _$hash = $jc(_$hash, userId.hashCode);
    _$hash = $jc(_$hash, title.hashCode);
    _$hash = $jc(_$hash, message.hashCode);
    _$hash = $jc(_$hash, dateSent.hashCode);
    _$hash = $jc(_$hash, isRead.hashCode);
    _$hash = $jc(_$hash, user.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'Notification')
          ..add('notificationId', notificationId)
          ..add('userId', userId)
          ..add('title', title)
          ..add('message', message)
          ..add('dateSent', dateSent)
          ..add('isRead', isRead)
          ..add('user', user))
        .toString();
  }
}

class NotificationBuilder
    implements Builder<Notification, NotificationBuilder> {
  _$Notification? _$v;

  int? _notificationId;
  int? get notificationId => _$this._notificationId;
  set notificationId(int? notificationId) =>
      _$this._notificationId = notificationId;

  String? _userId;
  String? get userId => _$this._userId;
  set userId(String? userId) => _$this._userId = userId;

  String? _title;
  String? get title => _$this._title;
  set title(String? title) => _$this._title = title;

  String? _message;
  String? get message => _$this._message;
  set message(String? message) => _$this._message = message;

  DateTime? _dateSent;
  DateTime? get dateSent => _$this._dateSent;
  set dateSent(DateTime? dateSent) => _$this._dateSent = dateSent;

  bool? _isRead;
  bool? get isRead => _$this._isRead;
  set isRead(bool? isRead) => _$this._isRead = isRead;

  UserBuilder? _user;
  UserBuilder get user => _$this._user ??= new UserBuilder();
  set user(UserBuilder? user) => _$this._user = user;

  NotificationBuilder() {
    Notification._defaults(this);
  }

  NotificationBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _notificationId = $v.notificationId;
      _userId = $v.userId;
      _title = $v.title;
      _message = $v.message;
      _dateSent = $v.dateSent;
      _isRead = $v.isRead;
      _user = $v.user?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(Notification other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$Notification;
  }

  @override
  void update(void Function(NotificationBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  Notification build() => _build();

  _$Notification _build() {
    _$Notification _$result;
    try {
      _$result = _$v ??
          new _$Notification._(
            notificationId: notificationId,
            userId: BuiltValueNullFieldError.checkNotNull(
                userId, r'Notification', 'userId'),
            title: BuiltValueNullFieldError.checkNotNull(
                title, r'Notification', 'title'),
            message: BuiltValueNullFieldError.checkNotNull(
                message, r'Notification', 'message'),
            dateSent: dateSent,
            isRead: isRead,
            user: _user?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'user';
        _user?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'Notification', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
