//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//

// ignore_for_file: unused_element
import 'package:openapi/src/model/user.dart';
import 'package:openapi/src/model/ticket_category.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'knowledge_base_article.g.dart';

/// KnowledgeBaseArticle
///
/// Properties:
/// * [articleID] 
/// * [title] 
/// * [content] 
/// * [categoryID] 
/// * [authorID] 
/// * [createdDate] 
/// * [updatedDate] 
/// * [isPublished] 
/// * [viewCount] 
/// * [category] 
/// * [author] 
@BuiltValue()
abstract class KnowledgeBaseArticle implements Built<KnowledgeBaseArticle, KnowledgeBaseArticleBuilder> {
  @BuiltValueField(wireName: r'articleID')
  int? get articleID;

  @BuiltValueField(wireName: r'title')
  String get title;

  @BuiltValueField(wireName: r'content')
  String get content;

  @BuiltValueField(wireName: r'categoryID')
  int? get categoryID;

  @BuiltValueField(wireName: r'authorID')
  String get authorID;

  @BuiltValueField(wireName: r'createdDate')
  DateTime get createdDate;

  @BuiltValueField(wireName: r'updatedDate')
  DateTime get updatedDate;

  @BuiltValueField(wireName: r'isPublished')
  bool get isPublished;

  @BuiltValueField(wireName: r'viewCount')
  int get viewCount;

  @BuiltValueField(wireName: r'category')
  TicketCategory? get category;
  // enum categoryEnum {  0,  1,  2,  3,  };

  @BuiltValueField(wireName: r'author')
  User? get author;

  KnowledgeBaseArticle._();

  factory KnowledgeBaseArticle([void updates(KnowledgeBaseArticleBuilder b)]) = _$KnowledgeBaseArticle;

  @BuiltValueHook(initializeBuilder: true)
  static void _defaults(KnowledgeBaseArticleBuilder b) => b;

  @BuiltValueSerializer(custom: true)
  static Serializer<KnowledgeBaseArticle> get serializer => _$KnowledgeBaseArticleSerializer();
}

class _$KnowledgeBaseArticleSerializer implements PrimitiveSerializer<KnowledgeBaseArticle> {
  @override
  final Iterable<Type> types = const [KnowledgeBaseArticle, _$KnowledgeBaseArticle];

  @override
  final String wireName = r'KnowledgeBaseArticle';

  Iterable<Object?> _serializeProperties(
    Serializers serializers,
    KnowledgeBaseArticle object, {
    FullType specifiedType = FullType.unspecified,
  }) sync* {
    if (object.articleID != null) {
      yield r'articleID';
      yield serializers.serialize(
        object.articleID,
        specifiedType: const FullType(int),
      );
    }
    yield r'title';
    yield serializers.serialize(
      object.title,
      specifiedType: const FullType(String),
    );
    yield r'content';
    yield serializers.serialize(
      object.content,
      specifiedType: const FullType(String),
    );
    if (object.categoryID != null) {
      yield r'categoryID';
      yield serializers.serialize(
        object.categoryID,
        specifiedType: const FullType.nullable(int),
      );
    }
    yield r'authorID';
    yield serializers.serialize(
      object.authorID,
      specifiedType: const FullType(String),
    );
    yield r'createdDate';
    yield serializers.serialize(
      object.createdDate,
      specifiedType: const FullType(DateTime),
    );
    yield r'updatedDate';
    yield serializers.serialize(
      object.updatedDate,
      specifiedType: const FullType(DateTime),
    );
    yield r'isPublished';
    yield serializers.serialize(
      object.isPublished,
      specifiedType: const FullType(bool),
    );
    yield r'viewCount';
    yield serializers.serialize(
      object.viewCount,
      specifiedType: const FullType(int),
    );
    if (object.category != null) {
      yield r'category';
      yield serializers.serialize(
        object.category,
        specifiedType: const FullType(TicketCategory),
      );
    }
    if (object.author != null) {
      yield r'author';
      yield serializers.serialize(
        object.author,
        specifiedType: const FullType(User),
      );
    }
  }

  @override
  Object serialize(
    Serializers serializers,
    KnowledgeBaseArticle object, {
    FullType specifiedType = FullType.unspecified,
  }) {
    return _serializeProperties(serializers, object, specifiedType: specifiedType).toList();
  }

  void _deserializeProperties(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
    required List<Object?> serializedList,
    required KnowledgeBaseArticleBuilder result,
    required List<Object?> unhandled,
  }) {
    for (var i = 0; i < serializedList.length; i += 2) {
      final key = serializedList[i] as String;
      final value = serializedList[i + 1];
      switch (key) {
        case r'articleID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.articleID = valueDes;
          break;
        case r'title':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.title = valueDes;
          break;
        case r'content':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.content = valueDes;
          break;
        case r'categoryID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType.nullable(int),
          ) as int?;
          if (valueDes == null) continue;
          result.categoryID = valueDes;
          break;
        case r'authorID':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(String),
          ) as String;
          result.authorID = valueDes;
          break;
        case r'createdDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.createdDate = valueDes;
          break;
        case r'updatedDate':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(DateTime),
          ) as DateTime;
          result.updatedDate = valueDes;
          break;
        case r'isPublished':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(bool),
          ) as bool;
          result.isPublished = valueDes;
          break;
        case r'viewCount':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(int),
          ) as int;
          result.viewCount = valueDes;
          break;
        case r'category':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(TicketCategory),
          ) as TicketCategory;
          result.category = valueDes;
          break;
        case r'author':
          final valueDes = serializers.deserialize(
            value,
            specifiedType: const FullType(User),
          ) as User;
          result.author.replace(valueDes);
          break;
        default:
          unhandled.add(key);
          unhandled.add(value);
          break;
      }
    }
  }

  @override
  KnowledgeBaseArticle deserialize(
    Serializers serializers,
    Object serialized, {
    FullType specifiedType = FullType.unspecified,
  }) {
    final result = KnowledgeBaseArticleBuilder();
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

