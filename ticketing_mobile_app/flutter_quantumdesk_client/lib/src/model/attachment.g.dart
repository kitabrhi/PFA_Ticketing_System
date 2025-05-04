// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'attachment.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$Attachment extends Attachment {
  @override
  final int? attachmentId;
  @override
  final int ticketID;
  @override
  final String? fileName;
  @override
  final String filePath;
  @override
  final DateTime? uploadedDate;
  @override
  final String uploaderUserId;
  @override
  final Ticket? ticket;
  @override
  final User? uploader;

  factory _$Attachment([void Function(AttachmentBuilder)? updates]) =>
      (new AttachmentBuilder()..update(updates))._build();

  _$Attachment._(
      {this.attachmentId,
      required this.ticketID,
      this.fileName,
      required this.filePath,
      this.uploadedDate,
      required this.uploaderUserId,
      this.ticket,
      this.uploader})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(ticketID, r'Attachment', 'ticketID');
    BuiltValueNullFieldError.checkNotNull(filePath, r'Attachment', 'filePath');
    BuiltValueNullFieldError.checkNotNull(
        uploaderUserId, r'Attachment', 'uploaderUserId');
  }

  @override
  Attachment rebuild(void Function(AttachmentBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  AttachmentBuilder toBuilder() => new AttachmentBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is Attachment &&
        attachmentId == other.attachmentId &&
        ticketID == other.ticketID &&
        fileName == other.fileName &&
        filePath == other.filePath &&
        uploadedDate == other.uploadedDate &&
        uploaderUserId == other.uploaderUserId &&
        ticket == other.ticket &&
        uploader == other.uploader;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, attachmentId.hashCode);
    _$hash = $jc(_$hash, ticketID.hashCode);
    _$hash = $jc(_$hash, fileName.hashCode);
    _$hash = $jc(_$hash, filePath.hashCode);
    _$hash = $jc(_$hash, uploadedDate.hashCode);
    _$hash = $jc(_$hash, uploaderUserId.hashCode);
    _$hash = $jc(_$hash, ticket.hashCode);
    _$hash = $jc(_$hash, uploader.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'Attachment')
          ..add('attachmentId', attachmentId)
          ..add('ticketID', ticketID)
          ..add('fileName', fileName)
          ..add('filePath', filePath)
          ..add('uploadedDate', uploadedDate)
          ..add('uploaderUserId', uploaderUserId)
          ..add('ticket', ticket)
          ..add('uploader', uploader))
        .toString();
  }
}

class AttachmentBuilder implements Builder<Attachment, AttachmentBuilder> {
  _$Attachment? _$v;

  int? _attachmentId;
  int? get attachmentId => _$this._attachmentId;
  set attachmentId(int? attachmentId) => _$this._attachmentId = attachmentId;

  int? _ticketID;
  int? get ticketID => _$this._ticketID;
  set ticketID(int? ticketID) => _$this._ticketID = ticketID;

  String? _fileName;
  String? get fileName => _$this._fileName;
  set fileName(String? fileName) => _$this._fileName = fileName;

  String? _filePath;
  String? get filePath => _$this._filePath;
  set filePath(String? filePath) => _$this._filePath = filePath;

  DateTime? _uploadedDate;
  DateTime? get uploadedDate => _$this._uploadedDate;
  set uploadedDate(DateTime? uploadedDate) =>
      _$this._uploadedDate = uploadedDate;

  String? _uploaderUserId;
  String? get uploaderUserId => _$this._uploaderUserId;
  set uploaderUserId(String? uploaderUserId) =>
      _$this._uploaderUserId = uploaderUserId;

  TicketBuilder? _ticket;
  TicketBuilder get ticket => _$this._ticket ??= new TicketBuilder();
  set ticket(TicketBuilder? ticket) => _$this._ticket = ticket;

  UserBuilder? _uploader;
  UserBuilder get uploader => _$this._uploader ??= new UserBuilder();
  set uploader(UserBuilder? uploader) => _$this._uploader = uploader;

  AttachmentBuilder() {
    Attachment._defaults(this);
  }

  AttachmentBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _attachmentId = $v.attachmentId;
      _ticketID = $v.ticketID;
      _fileName = $v.fileName;
      _filePath = $v.filePath;
      _uploadedDate = $v.uploadedDate;
      _uploaderUserId = $v.uploaderUserId;
      _ticket = $v.ticket?.toBuilder();
      _uploader = $v.uploader?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(Attachment other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$Attachment;
  }

  @override
  void update(void Function(AttachmentBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  Attachment build() => _build();

  _$Attachment _build() {
    _$Attachment _$result;
    try {
      _$result = _$v ??
          new _$Attachment._(
            attachmentId: attachmentId,
            ticketID: BuiltValueNullFieldError.checkNotNull(
                ticketID, r'Attachment', 'ticketID'),
            fileName: fileName,
            filePath: BuiltValueNullFieldError.checkNotNull(
                filePath, r'Attachment', 'filePath'),
            uploadedDate: uploadedDate,
            uploaderUserId: BuiltValueNullFieldError.checkNotNull(
                uploaderUserId, r'Attachment', 'uploaderUserId'),
            ticket: _ticket?.build(),
            uploader: _uploader?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'ticket';
        _ticket?.build();
        _$failedField = 'uploader';
        _uploader?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'Attachment', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
