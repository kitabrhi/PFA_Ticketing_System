// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'knowledge_base_article.dart';

// **************************************************************************
// BuiltValueGenerator
// **************************************************************************

class _$KnowledgeBaseArticle extends KnowledgeBaseArticle {
  @override
  final int? articleID;
  @override
  final String title;
  @override
  final String content;
  @override
  final int? categoryID;
  @override
  final String authorID;
  @override
  final DateTime createdDate;
  @override
  final DateTime updatedDate;
  @override
  final bool isPublished;
  @override
  final int viewCount;
  @override
  final TicketCategory? category;
  @override
  final User? author;

  factory _$KnowledgeBaseArticle(
          [void Function(KnowledgeBaseArticleBuilder)? updates]) =>
      (new KnowledgeBaseArticleBuilder()..update(updates))._build();

  _$KnowledgeBaseArticle._(
      {this.articleID,
      required this.title,
      required this.content,
      this.categoryID,
      required this.authorID,
      required this.createdDate,
      required this.updatedDate,
      required this.isPublished,
      required this.viewCount,
      this.category,
      this.author})
      : super._() {
    BuiltValueNullFieldError.checkNotNull(
        title, r'KnowledgeBaseArticle', 'title');
    BuiltValueNullFieldError.checkNotNull(
        content, r'KnowledgeBaseArticle', 'content');
    BuiltValueNullFieldError.checkNotNull(
        authorID, r'KnowledgeBaseArticle', 'authorID');
    BuiltValueNullFieldError.checkNotNull(
        createdDate, r'KnowledgeBaseArticle', 'createdDate');
    BuiltValueNullFieldError.checkNotNull(
        updatedDate, r'KnowledgeBaseArticle', 'updatedDate');
    BuiltValueNullFieldError.checkNotNull(
        isPublished, r'KnowledgeBaseArticle', 'isPublished');
    BuiltValueNullFieldError.checkNotNull(
        viewCount, r'KnowledgeBaseArticle', 'viewCount');
  }

  @override
  KnowledgeBaseArticle rebuild(
          void Function(KnowledgeBaseArticleBuilder) updates) =>
      (toBuilder()..update(updates)).build();

  @override
  KnowledgeBaseArticleBuilder toBuilder() =>
      new KnowledgeBaseArticleBuilder()..replace(this);

  @override
  bool operator ==(Object other) {
    if (identical(other, this)) return true;
    return other is KnowledgeBaseArticle &&
        articleID == other.articleID &&
        title == other.title &&
        content == other.content &&
        categoryID == other.categoryID &&
        authorID == other.authorID &&
        createdDate == other.createdDate &&
        updatedDate == other.updatedDate &&
        isPublished == other.isPublished &&
        viewCount == other.viewCount &&
        category == other.category &&
        author == other.author;
  }

  @override
  int get hashCode {
    var _$hash = 0;
    _$hash = $jc(_$hash, articleID.hashCode);
    _$hash = $jc(_$hash, title.hashCode);
    _$hash = $jc(_$hash, content.hashCode);
    _$hash = $jc(_$hash, categoryID.hashCode);
    _$hash = $jc(_$hash, authorID.hashCode);
    _$hash = $jc(_$hash, createdDate.hashCode);
    _$hash = $jc(_$hash, updatedDate.hashCode);
    _$hash = $jc(_$hash, isPublished.hashCode);
    _$hash = $jc(_$hash, viewCount.hashCode);
    _$hash = $jc(_$hash, category.hashCode);
    _$hash = $jc(_$hash, author.hashCode);
    _$hash = $jf(_$hash);
    return _$hash;
  }

  @override
  String toString() {
    return (newBuiltValueToStringHelper(r'KnowledgeBaseArticle')
          ..add('articleID', articleID)
          ..add('title', title)
          ..add('content', content)
          ..add('categoryID', categoryID)
          ..add('authorID', authorID)
          ..add('createdDate', createdDate)
          ..add('updatedDate', updatedDate)
          ..add('isPublished', isPublished)
          ..add('viewCount', viewCount)
          ..add('category', category)
          ..add('author', author))
        .toString();
  }
}

class KnowledgeBaseArticleBuilder
    implements Builder<KnowledgeBaseArticle, KnowledgeBaseArticleBuilder> {
  _$KnowledgeBaseArticle? _$v;

  int? _articleID;
  int? get articleID => _$this._articleID;
  set articleID(int? articleID) => _$this._articleID = articleID;

  String? _title;
  String? get title => _$this._title;
  set title(String? title) => _$this._title = title;

  String? _content;
  String? get content => _$this._content;
  set content(String? content) => _$this._content = content;

  int? _categoryID;
  int? get categoryID => _$this._categoryID;
  set categoryID(int? categoryID) => _$this._categoryID = categoryID;

  String? _authorID;
  String? get authorID => _$this._authorID;
  set authorID(String? authorID) => _$this._authorID = authorID;

  DateTime? _createdDate;
  DateTime? get createdDate => _$this._createdDate;
  set createdDate(DateTime? createdDate) => _$this._createdDate = createdDate;

  DateTime? _updatedDate;
  DateTime? get updatedDate => _$this._updatedDate;
  set updatedDate(DateTime? updatedDate) => _$this._updatedDate = updatedDate;

  bool? _isPublished;
  bool? get isPublished => _$this._isPublished;
  set isPublished(bool? isPublished) => _$this._isPublished = isPublished;

  int? _viewCount;
  int? get viewCount => _$this._viewCount;
  set viewCount(int? viewCount) => _$this._viewCount = viewCount;

  TicketCategory? _category;
  TicketCategory? get category => _$this._category;
  set category(TicketCategory? category) => _$this._category = category;

  UserBuilder? _author;
  UserBuilder get author => _$this._author ??= new UserBuilder();
  set author(UserBuilder? author) => _$this._author = author;

  KnowledgeBaseArticleBuilder() {
    KnowledgeBaseArticle._defaults(this);
  }

  KnowledgeBaseArticleBuilder get _$this {
    final $v = _$v;
    if ($v != null) {
      _articleID = $v.articleID;
      _title = $v.title;
      _content = $v.content;
      _categoryID = $v.categoryID;
      _authorID = $v.authorID;
      _createdDate = $v.createdDate;
      _updatedDate = $v.updatedDate;
      _isPublished = $v.isPublished;
      _viewCount = $v.viewCount;
      _category = $v.category;
      _author = $v.author?.toBuilder();
      _$v = null;
    }
    return this;
  }

  @override
  void replace(KnowledgeBaseArticle other) {
    ArgumentError.checkNotNull(other, 'other');
    _$v = other as _$KnowledgeBaseArticle;
  }

  @override
  void update(void Function(KnowledgeBaseArticleBuilder)? updates) {
    if (updates != null) updates(this);
  }

  @override
  KnowledgeBaseArticle build() => _build();

  _$KnowledgeBaseArticle _build() {
    _$KnowledgeBaseArticle _$result;
    try {
      _$result = _$v ??
          new _$KnowledgeBaseArticle._(
            articleID: articleID,
            title: BuiltValueNullFieldError.checkNotNull(
                title, r'KnowledgeBaseArticle', 'title'),
            content: BuiltValueNullFieldError.checkNotNull(
                content, r'KnowledgeBaseArticle', 'content'),
            categoryID: categoryID,
            authorID: BuiltValueNullFieldError.checkNotNull(
                authorID, r'KnowledgeBaseArticle', 'authorID'),
            createdDate: BuiltValueNullFieldError.checkNotNull(
                createdDate, r'KnowledgeBaseArticle', 'createdDate'),
            updatedDate: BuiltValueNullFieldError.checkNotNull(
                updatedDate, r'KnowledgeBaseArticle', 'updatedDate'),
            isPublished: BuiltValueNullFieldError.checkNotNull(
                isPublished, r'KnowledgeBaseArticle', 'isPublished'),
            viewCount: BuiltValueNullFieldError.checkNotNull(
                viewCount, r'KnowledgeBaseArticle', 'viewCount'),
            category: category,
            author: _author?.build(),
          );
    } catch (_) {
      late String _$failedField;
      try {
        _$failedField = 'author';
        _author?.build();
      } catch (e) {
        throw new BuiltValueNestedFieldError(
            r'KnowledgeBaseArticle', _$failedField, e.toString());
      }
      rethrow;
    }
    replace(_$result);
    return _$result;
  }
}

// ignore_for_file: deprecated_member_use_from_same_package,type=lint
