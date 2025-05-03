// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ticket_history.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$TicketHistory extends TicketHistory {
  @override
  final int? ticketHistoryID;
  @override
  final int ticketID;
  @override
  final String changedByUserId;
  @override
  final String fieldName;
  @override
  final String? oldValue;
  @override
  final String? newValue;
  @override
  final DateTime? changedDate;
  @override
  final User? changedByUser;

  factory _$TicketHistory([void Function(TicketHistoryBuilder)? updates]) =>
      (new TicketHistoryBuilder()..update(updates))._build();

  _$TicketHistory._(
      {this.ticketHistoryID,
      required this.ticketID,
      required this.changedByUserId,
      required this.fieldName,
      this.oldValue,
      this.newValue,
      this.changedDate,
      this.changedByUser})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(
        ticketID, r'TicketHistory', 'ticketID');
    BuiltValueNullFieldError.checkNotNull(
        changedByUserId, r'TicketHistory', 'changedByUserId');
    BuiltValueNullFieldError.checkNotNull(
        fieldName, r'TicketHistory', 'fieldName');
  }

  @override
  TicketHistory rebuild(void Function(TicketHistoryBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  TicketHistoryBuilder toBuilder() => new TicketHistoryBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is TicketHistory &&
        ticketHistoryID == other.ticketHistoryID &&
        ticketID == other.ticketID &&
        changedByUserId == other.changedByUserId &&
        fieldName == other.fieldName &&
        oldValue == other.oldValue &&
        newValue == other.newValue &&
        changedDate == other.changedDate &&
        changedByUser == other.changedByUser;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, ticketHistoryID.hashCode);
    _$hash = $jc(_$hash, ticketID.hashCode);
    _$hash = $jc(_$hash, changedByUserId.hashCode);
    _$hash = $jc(_$hash, fieldName.hashCode);
    _$hash = $jc(_$hash, oldValue.hashCode);
    _$hash = $jc(_$hash, newValue.hashCode);
    _$hash = $jc(_$hash, changedDate.hashCode);
    _$hash = $jc(_$hash, changedByUser.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'TicketHistory')
          ..add('ticketHistoryID', ticketHistoryID)
          ..add('ticketID', ticketID)
          ..add('changedByUserId', changedByUserId)
          ..add('fieldName', fieldName)
          ..add('oldValue', oldValue)
          ..add('newValue', newValue)
          ..add('changedDate', changedDate)
          ..add('changedByUser', changedByUser))
        .toString();
  }
}

class TicketHistoryBuilder
    implements Builder<TicketHistory, TicketHistoryBuilder> {
  _$TicketHistory? _$v;

  int? _ticketHistoryID;
  int? get ticketHistoryID => _$this._ticketHistoryID;
  set ticketHistoryID(int? ticketHistoryID) =>
      _$this._ticketHistoryID = ticketHistoryID;

  int? _ticketID;
  int? get ticketID => _$this._ticketID;
  set ticketID(int? ticketID) => _$this._ticketID = ticketID;

  String? _changedByUserId;
  String? get changedByUserId => _$this._changedByUserId;
  set changedByUserId(String? changedByUserId) =>
      _$this._changedByUserId = changedByUserId;

  String? _fieldName;
  String? get fieldName => _$this._fieldName;
  set fieldName(String? fieldName) => _$this._fieldName = fieldName;

  String? _oldValue;
  String? get oldValue => _$this._oldValue;
  set oldValue(String? oldValue) => _$this._oldValue = oldValue;

  String? _newValue;
  String? get newValue => _$this._newValue;
  set newValue(String? newValue) => _$this._newValue = newValue;

  DateTime? _changedDate;
  DateTime? get changedDate => _$this._changedDate;
  set changedDate(DateTime? changedDate) => _$this._changedDate = changedDate;

  UserBuilder? _changedByUser;
  UserBuilder get changedByUser => _$this._changedByUser ??= new UserBuilder();
  set changedByUser(UserBuilder? changedByUser) =>
      _$this._changedByUser = changedByUser;

  TicketHistoryBuilder() {
    TicketHistory._defaults(this);
  }

  TicketHistoryBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _ticketHistoryID = $v.ticketHistoryID;
      _ticketID = $v.ticketID;
      _changedByUserId = $v.changedByUserId;
      _fieldName = $v.fieldName;
      _oldValue = $v.oldValue;
      _newValue = $v.newValue;
      _changedDate = $v.changedDate;
      _changedByUser = $v.changedByUser?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(TicketHistory other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$TicketHistory;
  }

  @override
  void update(void Function(TicketHistoryBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  TicketHistory build() => _build();

  _$TicketHistory _build() {
    _$TicketHistory _$result;
    try {
      _$result = _$v ??
          new _$TicketHistory._(
            ticketHistoryID: ticketHistoryID,
            ticketID: BuiltValueNullFieldError.checkNotNull(
                ticketID, r'TicketHistory', 'ticketID'),
            changedByUserId: BuiltValueNullFieldError.checkNotNull(
                changedByUserId, r'TicketHistory', 'changedByUserId'),
            fieldName: BuiltValueNullFieldError.checkNotNull(
                fieldName, r'TicketHistory', 'fieldName'),
            oldValue: oldValue,
            newValue: newValue,
            changedDate: changedDate,
            changedByUser: _changedByUser?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'changedByUser';
        _changedByUser?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'TicketHistory', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
