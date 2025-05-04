//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:built_collection/built_collection.dart';
import 'package:openapi/src/model/user.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'edit_user_model.g.dart';

/// EditUserModel
///
/// Properties:
/// * [user] 
/// * [selectedRoles] 
@BuiltValue()
abstract class EditUserModel implements Built<EditUserModel, EditUserModelBuilder> {
  @BuiltValueField(wireName: r'user')
  User? get user;

  @BuiltValueField(wireName: r'selectedRoles')
  BuiltList<String>? get selectedRoles;

  EditUserModel._();

  factory EditUserModel([void updates(EditUserModelBuilder b)]) = _$EditUserModel;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(EditUserModelBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<EditUserModel> get serializer => _$EditUserModelSerializer();
}

class _$EditUserModelSerializer implements PrimitiveSerializer<EditUserModel> {
  @override
  final Iterable<Type> types = const [EditUserModel, _$EditUserModel];

  @override
  final String wireName = r'EditUserModel';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    EditUserModel object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.user != null) {
      yield r'user';
      yield serializers.serialize(
        object.user,
        specifiedType: const FullType(User),
      );
    }
    if (object.selectedRoles != null) {
      yield r'selectedRoles';
      yield serializers.serialize(
        object.selectedRoles,
        specifiedType: const FullType.nullable(BuiltList, [FullType(String)]),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    EditUserModel object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required EditUserModelBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'user':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.user.replace(valueDes);
          break;
        case r'selectedRoles':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(BuiltList, [FullType(String)]),
          ) as BuiltList<String>?;
          if (valueDes == null) continue;
          result.selectedRoles.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  EditUserModel deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = EditUserModelBuilder();
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

