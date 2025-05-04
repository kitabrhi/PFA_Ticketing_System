//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/user.dart';
import 'package:openapi/src/model/ticket.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'attachment.g.dart';

/// Attachment
///
/// Properties:
/// * [attachmentId] 
/// * [ticketID] 
/// * [fileName] 
/// * [filePath] 
/// * [uploadedDate] 
/// * [uploaderUserId] 
/// * [ticket] 
/// * [uploader] 
@BuiltValue()
abstract class Attachment implements Built<Attachment, AttachmentBuilder> {
  @BuiltValueField(wireName: r'attachmentId')
  int? get attachmentId;

  @BuiltValueField(wireName: r'ticketID')
  int get ticketID;

  @BuiltValueField(wireName: r'fileName')
  String? get fileName;

  @BuiltValueField(wireName: r'filePath')
  String get filePath;

  @BuiltValueField(wireName: r'uploadedDate')
  DateTime? get uploadedDate;

  @BuiltValueField(wireName: r'uploaderUserId')
  String get uploaderUserId;

  @BuiltValueField(wireName: r'ticket')
  Ticket? get ticket;

  @BuiltValueField(wireName: r'uploader')
  User? get uploader;

  Attachment._();

  factory Attachment([void updates(AttachmentBuilder b)]) = _$Attachment;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(AttachmentBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<Attachment> get serializer => _$AttachmentSerializer();
}

class _$AttachmentSerializer implements PrimitiveSerializer<Attachment> {
  @override
  final Iterable<Type> types = const [Attachment, _$Attachment];

  @override
  final String wireName = r'Attachment';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    Attachment object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.attachmentId != null) {
      yield r'attachmentId';
      yield serializers.serialize(
        object.attachmentId,
        specifiedType: const FullType(int),
      );
    }
    yield r'ticketID';
    yield serializers.serialize(
      object.ticketID,
      specifiedType: const FullType(int),
    );
    if (object.fileName != null) {
      yield r'fileName';
      yield serializers.serialize(
        object.fileName,
        specifiedType: const FullType.nullable(String),
      );
    }
    yield r'filePath';
    yield serializers.serialize(
      object.filePath,
      specifiedType: const FullType(String),
    );
    if (object.uploadedDate != null) {
      yield r'uploadedDate';
      yield serializers.serialize(
        object.uploadedDate,
        specifiedType: const FullType(DateTime),
      );
    }
    yield r'uploaderUserId';
    yield serializers.serialize(
      object.uploaderUserId,
      specifiedType: const FullType(String),
    );
    if (object.ticket != null) {
      yield r'ticket';
      yield serializers.serialize(
        object.ticket,
        specifiedType: const FullType(Ticket),
      );
    }
    if (object.uploader != null) {
      yield r'uploader';
      yield serializers.serialize(
        object.uploader,
        specifiedType: const FullType(User),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    Attachment object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required AttachmentBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'attachmentId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.attachmentId = valueDes;
          break;
        case r'ticketID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.ticketID = valueDes;
          break;
        case r'fileName':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(String),
          ) as String?;
          if (valueDes == null) continue;
          result.fileName = valueDes;
          break;
        case r'filePath':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.filePath = valueDes;
          break;
        case r'uploadedDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.uploadedDate = valueDes;
          break;
        case r'uploaderUserId':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.uploaderUserId = valueDes;
          break;
        case r'ticket':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(Ticket),
          ) as Ticket;
          result.ticket.replace(valueDes);
          break;
        case r'uploader':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.uploader.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  Attachment deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = AttachmentBuilder();
    final serializedList = (serialized as Iterable<Object?>).toList();
    final unhandled = <Object?>[];
    _deserializeProperties(
      serializers,
      serialized,
      specifiedType: specifiedType,
      serializedList: serializedList,
      unhandled: unhandled,
      result: result,
    );
    return result.build();
  }
}

